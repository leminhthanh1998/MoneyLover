using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class TLPROFILE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TLID { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        public int DepartmentID { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
