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
        /// <returns>All the articles.</returns>
        public IQueryable<Currency> GetCurrencies();

        /// <summary>
        /// Get all the currencies.
        /// </summary>
        /// <returns>All the articles.</returns>
        //public IQueryable<Article> GetArticlesByTemplate(string template);

        /// <summary>
        /// Get specific article with choosen id.
        /// </summary>
        /// <param name="id">Id of the article.</param>
        /// <returns>Article with choosen id.</returns>
        public Currency GetCurrencyById(int id);
        
        public Currency GetCurrencyByName(string name);
        
        /// <summary>
        /// Save article.
        /// </summary>
        /// <param name="entity">Article that should be saved.</param>
        public void SaveCurrency(Currency entity);

        ///// <summary>
        ///// Delete article with choosen id.
        ///// </summary>
        ///// <param name="id">Id of the article.</param>
        //void DeleteArticle(Guid id);

        /// <summary>
        /// Get amount of articles in the database.
        /// </summary>
        /// <returns>Amount of articles.</returns>
        //public int GetAmountOfArticles();

        /// <summary>
        /// Checks is repository contains article.
        /// </summary>
        /// <param name="entity">Article.</param>
        /// <returns></returns>
        //public bool Contains(Article entity);
    }
}