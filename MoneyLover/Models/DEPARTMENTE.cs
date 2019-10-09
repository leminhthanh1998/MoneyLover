using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class DEPARTMENTE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public int BRID { get; set; }
        public int TLID { get; set; }
        public string Status { get; set; }
    }
}
