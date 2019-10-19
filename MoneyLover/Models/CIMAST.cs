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
      
        //so tien goc
        public double? DEPOSITAMT { get; set; }
        //lai suat nam
        public double RATE { get; set; }
       
      
        //ngay mo
        public DateTime FRDATE { get; set; }
        
        //khong ky han
        public double? NPTERM { get; set; }
        //ngan hang
        public string BANK { get; set; }
        //tra lai la sao nhi
        public string TraLai { get; set; }
        //khi den han
        public string KhiDenHan { get; set; }
        //ky han
        public int TERM { get; set; }
        //số dư hiện có
        public double? Balance { get; set; }
        //trạng thái
        public string STT { get; set; }
    }
}
