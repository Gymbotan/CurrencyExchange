using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Models
{
    public class Record
    {
        [Key]
        public Guid Guid { get; set; }
        public int Cur_ID { get; set; }
        public string Cur_Name { get; set; }
        //public string Code { get; set; }
        public DateTime Date { get; set; }
        public double Cur_OfficialRate { get; set; }
    }
}
