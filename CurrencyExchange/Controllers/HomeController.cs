using CurrencyExchange.Domain;
using CurrencyExchange.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
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
        private List<Record> records;

        public IConfiguration Configuration { get; }
        private Storage Storage { get; set; }
        
        public HomeController(IConfiguration configuration, Storage storage)
        {
            this.Configuration = configuration;
            this.Storage = storage;
            this.records = new List<Record>();
            //{new Record{ Cur_ID=1, Date=DateTime.Now, Cur_OfficialRate=1.1},
            //new Record{ Cur_ID=1, Date=DateTime.Now, Cur_OfficialRate=1.2},
            //new Record{ Cur_ID=1, Date=DateTime.Now, Cur_OfficialRate=1.3}};
        }

        public IActionResult IndexAsync()
        {
            //Used to add currencies to DB.
            //var client = new HttpClient();
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
            Currency currency = Storage.currenciesRepository.GetCurrencyByName(selectedCur);
            var msg = await client.GetStringAsync($"https://www.nbrb.by/api/exrates/rates/dynamics/{currency.Cur_ID}?startdate={DateToString(dateStart)}&enddate={DateToString(dateEnd)}");
            records = JsonSerializer.Deserialize<List<Record>>(msg);
            for(int i = 0; i < records.Count; i++)
            {
                records[i].Cur_Name = selectedCur;
                Storage.currenciesOndateRepository.SaveRecord(records[i]);
            }
            ViewBag.CurrencyName = selectedCur;
            //ViewBag.Records = records;

            return View(Storage.currenciesOndateRepository.GetRecords());
        }

        public ActionResult Remove(Guid guid)
        {
            //records.RemoveAt(row);
            //Guid id = new Guid(guid);
            Currency cur = Storage.currenciesRepository.GetCurrencyById(440);
            Storage.currenciesOndateRepository.DeleteRecord(guid);
            return View(Storage.currenciesOndateRepository.GetRecords());
        }

        //public ActionResult Show1(int row)
        //{
        //    //List<Record> records = (List<Record>) TempData["Records"];
        //    records.RemoveAt(row);
        //    ViewBag.Records = records;
        //    return View(records);
        //}

        //public async Task<ActionResult> Show(string dateStart, string dateEnd, Currency selecedCur)
        //{
        //    //var stringTask = client.GetStringAsync($"https://www.nbrb.by/api/exrates/rates/dynamics/{selecedCur.Cur_ID}?startdate={DateToString(dateStart)}&enddate={DateToString(dateEnd)}");
        //    //var msg = await stringTask;
        //    //Record records = JsonSerializer.Deserialize<Record>(msg);

        //    return View();
        //}

        private string DateToString(DateTime date)
        {
            return $"{date.Year}-{date.Month:d2}-{date.Day:d2}";
        }
    }
}
