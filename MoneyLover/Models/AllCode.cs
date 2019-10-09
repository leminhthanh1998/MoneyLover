using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class AllCode
    {
        [Key, Column(Order = 1)]
        public string CDTYPE { get; set; }
        [Key, Column(Order = 2)]
        public string CDNAME { get; set; }
        [Key, Column(Order = 3)]
        public string CDVAL { get; set; }
        public string CDCONTENT { get; set; }
        public string EN_CDCONTENT { get; set; }
        public int LSTODR { get; set; }
        public string CDUSER { get; set; }
    }
}
