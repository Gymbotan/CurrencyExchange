using CurrencyExchange.Domain;
using CurrencyExchange.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IConfiguration Configuration { get; }
        private Storage Storage { get; set; }

        public HomeController(IConfiguration configuration, Storage storage)
        {
            this.Configuration = configuration;
            this.Storage = storage;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //Used to add currencies to DB.
            //var client = new HttpClient();
            //var msg = await client.GetStringAsync($"https://www.nbrb.by/api/exrates/currencies");
            //List<Currency> result = JsonSerializer.Deserialize<List<Currency>>(msg);

            //foreach (Currency currency in result)
            //{
            //    Storage.currenciesRepository.SaveCurrency(currency);
            //}


            //using (var connection = new SqliteConnection(Configuration["ConnectionString"]))
            //{
            //    connection.Open();
            //}
            return View();
        }
    }
}
