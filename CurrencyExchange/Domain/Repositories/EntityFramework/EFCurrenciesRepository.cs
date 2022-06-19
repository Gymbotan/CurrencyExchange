using CurrencyExchange.Domain.Repositories.Interfaces;
using CurrencyExchange.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Domain.Repositories.EntityFramework
{
    public class EFCurrenciesRepository : ICurrenciesRepository
    {
        private readonly AppDbContext context;

        public EFCurrenciesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Currency> GetCurrencies()
        {
            return context.Currencies;
        }

        public Currency GetCurrencyById(int id)
        {
            return context.Currencies.FirstOrDefault(x => x.Cur_ID == id);
        }

        public Currency GetCurrencyByName(string name)
        {
            return context.Currencies.FirstOrDefault(x => x.Cur_Name == name);
        }

        public void SaveCurrency(Currency entity)
        {
            if (context.Currencies.FirstOrDefault(x => x.Cur_ID == entity.Cur_ID) == null)
            {
                context.Currencies.Add(entity);
                //context.Entry(entity).State = EntityState.Added;
            }
            
            context.SaveChanges();
        }
    }
}
