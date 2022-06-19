using CurrencyExchange.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Domain
{
    public class Storage
    {
        public readonly ICurrenciesRepository currenciesRepository; 

        public readonly ICurrenciesOndateRepository currenciesOndateRepository;

        public Storage(ICurrenciesRepository currenciesRepository, ICurrenciesOndateRepository currenciesOndateRepository)
        {
            this.currenciesRepository = currenciesRepository;
            this.currenciesOndateRepository = currenciesOndateRepository;
        }
    }
}
