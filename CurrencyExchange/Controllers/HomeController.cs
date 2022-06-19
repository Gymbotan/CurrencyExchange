using CurrencyExchange.Domain;
using CurrencyExchange.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyExchange.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly ILogger<HomeController> logger;

        public IConfiguration Configuration { get; }
        private Storage Storage { get; set; }
        
        public HomeController(IConfiguration configuration, Storage storage, ILogger<HomeController> logger)
        {
            this.Configuration = configuration;
            this.Storage = storage;
            this.logger = logger;
        }

        public IActionResult IndexAsync()
        {
            //Used to add currencies to DB.
            //var msg = await client.GetStringAsync($"https://www.nbrb.by/api/exrates/currencies");
            //List<Currency> result = JsonSerializer.Deserialize<List<Currency>>(msg);
            //foreach (Currency currency in result)
            //{
            //    Storage.currenciesRepository.SaveCurrency(currency);
            //}

            ViewBag.today = DateToString(DateTime.Now);

            IQueryable<Currency> currenciesList = Storage.currenciesRepository.GetCurrencies();

            SelectList selectList = new SelectList(currenciesList, Storage.currenciesRepository.GetCurrencyById(431));
            ViewBag.SelectItems = selectList;

            return View(currenciesList);
        }

        public async Task<ActionResult> ShowAsync(DateTime dateStart, DateTime dateEnd, string selectedCur, int row)
        {
            if (dateStart > dateEnd)
            {
                DateTime temp = dateStart;
                dateStart = dateEnd;
                dateEnd = temp;
                logger.LogInformation("Начальная дата была меньше конечной. Даты поменяны местами.");
            }

            if (dateStart.AddDays(367) < dateEnd)
            {
                logger.LogWarning("Задан диапазон больше года. Возможно недополучение интересующей информации.");
            }

            Currency currency = Storage.currenciesRepository.GetCurrencyByName(selectedCur);
            var msg = await client.GetStringAsync($"https://www.nbrb.by/api/exrates/rates/dynamics/{currency.Cur_ID}?startdate={DateToString(dateStart)}&enddate={DateToString(dateEnd)}");
            List<Record> records = JsonSerializer.Deserialize<List<Record>>(msg);
            if (records.Count > 0)
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].Cur_Name = selectedCur;
                    Storage.currenciesOndateRepository.SaveRecord(records[i]);
                }
            }
            else
            {
                var msg2 = await client.GetStringAsync($"https://www.nbrb.by/api/exrates/rates/{currency.Cur_ID}");
                Record standardRecord = JsonSerializer.Deserialize<Record>(msg2);
                if (standardRecord.Cur_OfficialRate == 0)
                {
                    logger.LogWarning($"Данные по валюте {selectedCur} не были получены. Возможно данная валюта более не существует (не обслуживается).");
                }
                else
                {
                    DateTime date = dateStart;
                    while (date <= dateEnd)
                    {
                        Record rec = new();
                        rec.Cur_ID = standardRecord.Cur_ID;
                        rec.Cur_Name = selectedCur;
                        rec.Date = date;
                        rec.Cur_OfficialRate = standardRecord.Cur_OfficialRate;
                        Storage.currenciesOndateRepository.SaveRecord(rec);
                        date = date.AddDays(1);
                    }
                    logger.LogInformation($"Для валюты {selectedCur} на запрашиваемый период с {dateStart.ToShortDateString()} по {dateEnd.ToShortDateString()} данные недоступны. Был записан курс на текущий день.");
                }
            }

            return View(Storage.currenciesOndateRepository.GetRecords());
        }

        public ActionResult Remove(Guid guid)
        {
            Storage.currenciesOndateRepository.DeleteRecord(guid);
            return View(Storage.currenciesOndateRepository.GetRecords());
        }

        private string DateToString(DateTime date)
        {
            return $"{date.Year}-{date.Month:d2}-{date.Day:d2}";
        }
    }
}
