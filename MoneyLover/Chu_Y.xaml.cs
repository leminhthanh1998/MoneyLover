using MoneyLover.Models;
using MoneyLover.Views;
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

namespace MoneyLover
{
    /// <summary>
    /// Interaction logic for Chu_Y.xaml
    /// </summary>
    public partial class Chu_Y : Window
    {

        public Chu_Y()
        {
            InitializeComponent();
            int ngay = RutTien.kyhan * 30;
            txbcanhbao.Text = "Sổ tiết kiếm " + RutTien.sotk + " đến hạn ngày " + RutTien.han.AddDays(ngay).ToString("dd/MM/yyyy") + " số tiền rút ra trước hạn sẽ được tính theo lại suất không kỳ hạn ( " + RutTien.hantruoc + "%/năm). Bạn có muốn tiếp tục?";
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {


            for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
            {

                if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                    App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
            }
            DanhSachSTK dn = new DanhSachSTK();
            dn.ShowDialog();

        }

        private void btnCo_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new MoneyEntity())
            {
                var stk = db.CIMASTs.Where(x => x.ACCTNO == RutTien.sotk).Single();
                double? sotien = RutTien.sotien;
                int k = thisIsMagic(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) - thisIsMagic(stk.FRDATE.Year, stk.FRDATE.Month, stk.FRDATE.Day);
                    CITRAN rutien = new CITRAN()
                    {
                        ACCTNO = stk.ACCTNO,
                        BKDATE = DateTime.Now,
                        SoTienRut = sotien,
                        TienLai = (stk.Balance * RutTien.dem * (stk.NPTERM / 100)) / 365,
                        DemNgay =  RutTien.dem
                    };
                    db.cITRANs.Add(rutien);
                    stk.Balance = stk.Balance - sotien;
                    db.SaveChanges();

                    for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
                    {

                        if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                            App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
                    }
                    DanhSachSTK ds = new DanhSachSTK();
                    ds.ShowDialog();
            }
        }

        public int thisIsMagic(int year, int month, int day)
        {
            if (month < 3)
            {
                year--;
                month += 12;
            }
            return 365 * year + year / 4 - year / 100 + year / 400 + (153 * month - 457) / 5 + day - 306;
        }
    }
}

