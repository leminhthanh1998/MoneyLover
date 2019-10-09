using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class CIMAST
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //ma so
        public int ACCTNO { get; set; }
        public int CUSID { get; set; }
        //so tien goc
        public double? DEPOSITAMT { get; set; }
        //lai suat nam
        public double RATE { get; set; }
       
        public double INTEREST { get; set; }
        //ngay mo
        public DateTime FRDATE { get; set; }
        public DateTime TODATE { get; set; }
        public int ISBLOCKED { get; set; }
        public double BLOCKEDAMT { get; set; }
        public double INCREASEINT { get; set; }
       
        public string STATUS { get; set; }
    }
}
