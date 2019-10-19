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
        public static int sotk, kyhan,dem;
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
                kyhan = stk.TERM;
                sotien = double.Parse(txbSoTien.Text);
                hantruoc = stk.NPTERM;

                if (txbSoTien.Text == "" || txbSoTien.Text == null)
                {
                    MessageBox.Show("Vui lòng nhập vào số tiền ", "Thông báo", MessageBoxButton.OK);
                }
                else
                {
                    if (int.Parse(txbSoTien.Text) <= stk.Balance)
                    {                     
                        int daynow = thisIsMagic(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        int day = thisIsMagic(stk.FRDATE.Year, stk.FRDATE.Month, stk.FRDATE.Day);
                        int k = daynow - day;

                        if (stk.TERM == 0)
                        {
                            if (k > 15)

                            {
                                if (stk.DEPOSITAMT == stk.Balance)
                                {
                                    CITRAN rutien = new CITRAN()
                                    {
                                        ACCTNO = stk.ACCTNO,
                                        BKDATE = DateTime.Now,
                                        SoTienRut = double.Parse(txbSoTien.Text),
                                        TienLai = (stk.Balance * k * (stk.RATE / 100)) / 365,
                                        DemNgay = k  

                                    };
                                    db.cITRANs.Add(rutien);
                                    stk.Balance = stk.Balance - sotien;
                                    db.SaveChanges();
                                }

                                else
                                {
                                    stk.Balance = stk.Balance - sotien;
                                    db.SaveChanges();
                                    var lst = db.cITRANs.Where(x => x.ACCTNO == stk.ACCTNO).OrderByDescending(c => c.BKDATE).Select(c => c.BKDATE).ToList();
                                    var asd = lst[0]; // lấy ra ngày cuối cùng rút tiền
                                    int demlai = daynow - thisIsMagic(asd.Year, asd.Month, asd.Day); // đếm lại ngày tính lãi
                                    CITRAN rutien = new CITRAN()
                                    {
                                        ACCTNO = stk.ACCTNO,
                                        BKDATE = DateTime.Now,
                                        SoTienRut = double.Parse(txbSoTien.Text),
                                        TienLai = (stk.Balance * demlai * (stk.RATE / 100)) / 365,
                                        DemNgay = demlai

                                    };
                                    db.cITRANs.Add(rutien);
                                    db.SaveChanges();
                                }
                              

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

                                CITRAN rutien = new CITRAN();
                                rutien.ACCTNO = stk.ACCTNO;
                                rutien.BKDATE = DateTime.Now;
                                rutien.SoTienRut = double.Parse(txbSoTien.Text);
                                //if (stk.DEPOSITAMT == stk.Balance)
                               // {
                                    rutien.TienLai = (stk.Balance * (stk.TERM * 30) * (stk.RATE / 100)) / 12 + (stk.Balance *(k-(stk.TERM*30))* (stk.NPTERM / 100) / 365) ;
                                    rutien.DemNgay = k;
                                //}
                                //else
                                //{
                                //    var lst = db.cITRANs.Where(x => x.ACCTNO == stk.ACCTNO).OrderByDescending(c => c.BKDATE).Select(c => c.BKDATE).ToList();
                                //    var asd = lst[0]; // lấy ra ngày cuối cùng rút tiền
                                //    int demlai = daynow - thisIsMagic(asd.Year, asd.Month, asd.Day); // đếm lại ngày tính lãi

                                //    rutien.TienLai = sotien * demlai * (stk.RATE / 100) / 365;
                                //    rutien.DemNgay = demlai;
                                //}

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
                           
                               
                                if (stk.DEPOSITAMT == stk.Balance)
                                {
                                    dem = k;
                                    Chu_Y chuy = new Chu_Y();
                                    chuy.ShowDialog();
                                }

                                else
                                {
                                    var lst = db.cITRANs.Where(x => x.ACCTNO == stk.ACCTNO).OrderByDescending(c => c.BKDATE).Select(c => c.BKDATE).ToList();
                                    var asd = lst[0]; // lấy ra ngày cuối cùng rút tiền
                                    int demlai = daynow - thisIsMagic(asd.Year, asd.Month, asd.Day);
                                    dem = demlai;
                                    Chu_Y chuy = new Chu_Y();
                                    chuy.ShowDialog();
                                }
                                   

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
        public static int thisIsMagic(int year, int month, int day)
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
            Close();
        }
    }
}
