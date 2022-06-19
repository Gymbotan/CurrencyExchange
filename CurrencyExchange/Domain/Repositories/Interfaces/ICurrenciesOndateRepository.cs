using CurrencyExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Domain.Repositories.Interfaces
{
    public interface ICurrenciesOndateRepository
    {
        /// <summary>
        /// Get all the records.
        /// </summary>
        /// <returns>All the records.</returns>
        public IQueryable<Record> GetRecords();

        /// <summary>
        /// Get all the currencies.
        /// </summary>
        /// <returns>All the record.</returns>
        //public IQueryable<Article> GetArticlesByTemplate(string template);

        /// <summary>
        /// Get specific record with choosen id.
        /// </summary>
        /// <param name="id">Id of the record.</param>
        /// <returns>record with choosen id.</returns>
        public Record GetRecordByCode(string code);

        public Record GetRecordByDate(DateTime date);

        public Record GetRecordByCodeAndDate(string code, DateTime date);

        /// <summary>
        /// Save record.
        /// </summary>
        /// <param name="entity">record that should be saved.</param>
        public void SaveRecord(Record entity);

        /// <summary>
        /// Delete record with choosen id.
        /// </summary>
        /// <param name="id">Id of the record.</param>
        void DeleteRecord(Guid id);
    }
}
