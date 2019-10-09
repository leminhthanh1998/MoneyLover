using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class TLLOGS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AUTOID { get; set; }
        public string OFFTIME { get; set; }
        public string MSGACCT { get; set; }
        public int MSGAMT { get; set; }
        public string TXSTATUS { get; set; }
        public string WSNAME { get; set; }
        public string IPADDRESS { get; set; }
        public string TXDESC { get; set; }
        public DateTime BUSDATE { get; set; }
        public string DELTD { get; set; }
        public string TLTXCD { get; set; }
        public string CHID { get; set; }
        public int TLID { get; set; }
        public int BRID { get; set; }
        public string TXTIME { get; set; }
        public DateTime? TXDATE { get; set; }
        public string TXNUM { get; set; }
    }
}
