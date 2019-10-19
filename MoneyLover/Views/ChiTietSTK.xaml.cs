using MoneyLover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MoneyLover.Views
{
    /// <summary>
    /// Interaction logic for ChiTietSTK.xaml
    /// </summary>
    public partial class ChiTietSTK : Window
    {
        public ChiTietSTK()
        {
            InitializeComponent();
            using (var db = new MoneyEntity())
            {
                var stk = db.CIMASTs.Where(x => x.ACCTNO == DanhSachSTK.maSTKTT).Single();
                var lst = db.CIMASTs.ToList();
                List<CIMAST> lstTatToan = new List<CIMAST>();
                // samdata.Add(lst);

                for (int i = 0; i < lst.Count(); i++)
                {
                    if (lst[i].ACCTNO == stk.ACCTNO)
                    {
                        CIMAST ci = new CIMAST();
                        ci.ACCTNO = lst[i].ACCTNO;
                        ci.Balance = lst[i].Balance;
                        ci.BANK = lst[i].BANK;
                        ci.DEPOSITAMT = lst[i].DEPOSITAMT;
                        ci.FRDATE = lst[i].FRDATE;
                        ci.KhiDenHan = lst[i].KhiDenHan;
                        ci.NPTERM = lst[i].NPTERM;
                        ci.RATE = lst[i].RATE;
                        ci.TERM = lst[i].TERM;
                        ci.TraLai = lst[i].TraLai;
                        ci.STT = lst[i].STT;
                        lstTatToan.Add(ci);
                    }
                }
                dgrTattoan.ItemsSource = lstTatToan.ToList();
               
                txtTatToan.Text = stk.ACCTNO.ToString();

            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
