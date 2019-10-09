using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class BRANCH
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BRID { get; set; }
        public string BRName { get; set; }
        public string Address { get; set; }
        public int? REPRESENTATIVE { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public string Status { get; set; }
    }
}
