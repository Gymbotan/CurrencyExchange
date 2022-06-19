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
        public string Code { get; set; }
        public DateTime CurDate { get; set; }
        public decimal Cur_Val { get; set; }
    }
}
