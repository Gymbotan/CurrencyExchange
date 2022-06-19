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
        public List<Record> GetRecords();
    
        /// <summary>
        /// Save record.
        /// </summary>
        /// <param name="entity">Record that should be saved.</param>
        public void SaveRecord(Record entity);

        /// <summary>
        /// Delete record with choosen id.
        /// </summary>
        /// <param name="id">Id of the record.</param>        
        void DeleteRecord(Guid id);
    }
}
