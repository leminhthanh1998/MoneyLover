using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class CIPRODUCT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PDID { get; set; }
        public string NAME { get; set; }
        public int MAX { get; set; }
        public int MIN { get; set; }
        public string Type { get; set; }
        public int PTERM { get; set; }
        public int NPTERM { get; set; }
        public double RATE { get; set; }
        public double PDRATE { get; set; }
        public DateTime NPPAYDATE { get; set; }
        public DateTime EFFECTDATE { get; set; }
    }
}
