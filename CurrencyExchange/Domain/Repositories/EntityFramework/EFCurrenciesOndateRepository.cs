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
        public void DeleteRecord(Guid id)
        {
            throw new NotImplementedException();
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

        public IQueryable<Record> GetRecords()
        {
            throw new NotImplementedException();
        }

        public void SaveRecord(Record entity)
        {
            throw new NotImplementedException();
        }
    }
}
