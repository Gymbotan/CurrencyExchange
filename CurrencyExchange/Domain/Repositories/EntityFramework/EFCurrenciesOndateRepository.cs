using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.Repositories.Interfaces;
using CurrencyExchange.Models;

namespace CurrencyExchange.Domain.Repositories.EntityFramework
{
    public class EFCurrenciesOndateRepository : ICurrenciesOndateRepository
    {
        private readonly AppDbContext context;

        public EFCurrenciesOndateRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteRecord(int row)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(Guid id)
        {
            context.Currencies_Ondate.Remove(new Record { Guid = id });
            context.SaveChanges();
        }

        public Record GetRecordByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Record GetRecordByCodeAndDate(string code, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Record GetRecordByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Record> GetRecords()
        {
            return context.Currencies_Ondate.ToList();
        }

        public void SaveRecord(Record entity)
        {
            if (context.Currencies_Ondate.FirstOrDefault(x => x.Cur_ID == entity.Cur_ID && x.Date == entity.Date) == null)
            {
                context.Currencies_Ondate.Add(entity);
                //context.Entry(entity).State = EntityState.Added;
            }

            context.SaveChanges();
        }
    }
}
