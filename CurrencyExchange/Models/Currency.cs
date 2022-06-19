using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Models
{
    public class Currency
    {
        [Key]
        public int Cur_ID { get; set; }
        public string Cur_Code { get; set; }
        public string Cur_Abbreviation { get; set; }
        public string Cur_Name { get; set; }
        public string Cur_QuotName { get; set; }
    }
}
