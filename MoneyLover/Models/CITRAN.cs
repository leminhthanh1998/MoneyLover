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
        //số tài khoản
        public int ACCTNO { get; set; }
        //ngày rút tiền
        public DateTime BKDATE { get; set; }
        //số tiền rút
        public double? SoTienRut { get; set; }
        //lãi suất
        public double? TienLai { get; set; }
    }
}
