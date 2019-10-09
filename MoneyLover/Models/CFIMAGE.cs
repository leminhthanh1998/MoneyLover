using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class CFIMAGE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int USIMGID { get; set; }
        public int CUSID { get; set; }
        public string FTIMGURL { get; set; }
        public string BKIMGURL { get; set; }
        public string FGIMGURL { get; set; }

        public DateTime FRDATE { get; set; }
        public DateTime TODATE { get; set; }
        public string STATUS { get; set; }
    }
}
