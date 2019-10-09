using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class CITRAN
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AUTOID { get; set; }
        public DateTime BKDATE { get; set; }
        public string TLTXCD { get; set; }
        public string DELID { get; set; }
        public int NAMT { get; set; }
        public string TXFIELD { get; set; }
        public int ACCTNO { get; set; }
        public string TXNUM { get; set; }
        public string TRDESC { get; set; }
        public string TXUPDATE { get; set; }

        public double? BALANCE { get; set; }
        public DateTime? TXTDATE { get; set; }
    }
}
