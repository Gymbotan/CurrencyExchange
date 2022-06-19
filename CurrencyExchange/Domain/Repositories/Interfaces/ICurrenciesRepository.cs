using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Models;

namespace CurrencyExchange.Domain.Repositories.Interfaces
{
    /// <summary>
    /// Interface of a repository for currencies.
    /// </summary>
    public interface ICurrenciesRepository
    {
        /// <summary>
        /// Get all the currencies.
        /// </summary>
        /// <returns>All the currencies.</returns>
        public IQueryable<Currency> GetCurrencies();

        /// <summary>
        /// Get specific currency with choosen id.
        /// </summary>
        /// <param name="id">Id of the currency.</param>
        /// <returns>Currency with choosen id.</returns>
        public Currency GetCurrencyById(int id);

        /// <summary>
        /// Get specific currency with choosen name.
        /// </summary>
        /// <param name="name">Name of the currency.</param>
        /// <returns>Currency with choosen name.</returns>
        public Currency GetCurrencyByName(string name);

        /// <summary>
        /// Save currency.
        /// </summary>
        /// <param name="entity">Currency that should be saved.</param>
        public void SaveCurrency(Currency entity);
    }
}