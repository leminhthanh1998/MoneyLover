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
    /// Interaction logic for RutTien.xaml
    /// </summary>
    public partial class RutTien : Window
    {
        public static int sotk;
        public static DateTime han;
        public static double? hantruoc;
        public static double? sotien;
        public RutTien()
        {
            InitializeComponent();
            using (var db = new MoneyEntity())
            {
                var stk = db.CIMASTs.Where(x => x.ACCTNO == DanhSachSTK.maSTK).Single();
                txbSTK.Text = "Số tài khoản: " + stk.ACCTNO + "(số dư hiện tại: " + stk.Balance + ")";
            }
        }

        private void btnRut_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new MoneyEntity())
            {
                var stk = db.CIMASTs.Where(x => x.ACCTNO == DanhSachSTK.maSTK).Single();
                sotk = stk.ACCTNO;
                han = stk.FRDATE;
                if (txbSoTien.Text == "" || txbSoTien.Text == null)
                {
                    MessageBox.Show("Vui lòng nhập vào số tiền ", "Thông báo", MessageBoxButton.OK);
                }
                else
                {
                  
                
                if (int.Parse(txbSoTien.Text) <= stk.Balance)
                {
                    sotien = double.Parse(txbSoTien.Text);
                    hantruoc = stk.NPTERM;
                    int k = thisIsMagic(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) - thisIsMagic(stk.FRDATE.Year, stk.FRDATE.Month, stk.FRDATE.Day);

                    if (stk.TERM == 0)
                    {
                        if (k > 15)


                        {
                            CITRAN rutien = new CITRAN()
                            {
                                ACCTNO = stk.ACCTNO,
                                BKDATE = DateTime.Now,
                                SoTienRut = double.Parse(txbSoTien.Text),
                                TienLai = (sotien * k * (stk.RATE / 100)) / 365

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
                        else
                        {
                            MessageBox.Show("chưa đến hạn rút", "Thông báo", MessageBoxButton.OK);
                                for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
                                {

                                    if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                                        App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
                                }
                                DanhSachSTK ds = new DanhSachSTK();
                                ds.ShowDialog();

                            }

                        }
                    else
                    {
                        if (k >= (stk.TERM * 30))
                        {

                            CITRAN rutien = new CITRAN()
                            {
                                ACCTNO = stk.ACCTNO,
                                BKDATE = DateTime.Now,
                                SoTienRut = double.Parse(txbSoTien.Text),
                                TienLai = (sotien * (stk.TERM * 30) * (stk.RATE / 100)) / 12

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
                        else
                        {
                            Chu_Y chuy = new Chu_Y();
                            chuy.ShowDialog();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Số tiền phải nhỏ hơn số dư hiện tại ", "Thông báo", MessageBoxButton.OK);
                }
                }

            }

        }

        //tinh ngay rut tien
        public int thisIsMagic(int year, int month, int day)
        {
            if (month < 3)
            {
                year--;
                month += 12;
            }
            return 365 * year + year / 4 - year / 100 + year / 400 + (153 * month - 457) / 5 + day - 306;
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
            {

                if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                    App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
            }
            DanhSachSTK ds = new DanhSachSTK();
            ds.ShowDialog();
        }
    }
}
