using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class User
    {
        [Key]
        public string email { get; set; }
        public string pass { get; set; }
    }
}
