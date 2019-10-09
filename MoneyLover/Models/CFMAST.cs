using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class CFMAST
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CUSID { get; set; }
        public string FULLNAME { get; set; }
        public string SEX { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }
        public string COUNTRY { get; set; }
        public string IDCODE { get; set; }
        public string IDPLACE { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime IDDATE { get; set; }
        public string IDTYPE { get; set; }
        public string ADDRESS { get; set; }
        public string MAIL { get; set; }
        public int FAX { get; set; }
        public int TAXCODE { get; set; }
        public int PHONE { get; set; }
        public int BRID { get; set; }
        public string STATUS { get; set; }
    }
}
