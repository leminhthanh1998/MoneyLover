using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class CALENDAR
    {
        public DateTime SBDATE { get; set; }
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AUTOID { get; set; }
        public string CLDRTYPE { get; set; }
        public string ISHOLIDAY { get; set; }
    }
}
