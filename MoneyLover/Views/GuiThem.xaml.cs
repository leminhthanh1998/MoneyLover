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
    /// Interaction logic for GuiThem.xaml
    /// </summary>
    public partial class GuiThem : Window
    {
        public GuiThem()
        {
            InitializeComponent();
            using (var db = new MoneyEntity())
            {
                var stk = db.CIMASTs.Where(x => x.ACCTNO == DanhSachSTK.maSTK).Single();
                txbSTK.Text = "Số tài khoản: " + stk.ACCTNO + "(số dư hiện tại: " + stk.Balance + ")";
            }
        }

        private void btnGui_Click(object sender, RoutedEventArgs e)
        {   
            using (var db = new MoneyEntity())
            {
                var stk = db.CIMASTs.Where(x => x.ACCTNO == DanhSachSTK.maSTK).Single();

                    GUITHEM gui = new GUITHEM()
                    {
                        NgayGui = DateTime.Now,
                        SoTienGui = int.Parse(txbSoTien.Text),
                        STK = stk.ACCTNO
                    };
                    db.gUITHEMs.Add(gui);
                    stk.Balance = stk.Balance + int.Parse(txbSoTien.Text);
                    db.SaveChanges();
                    MessageBox.Show("Gửi thành công", "Thông báo", MessageBoxButton.OK);

                    for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
                    {

                        if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                            App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
                    }
                    DanhSachSTK rut = new DanhSachSTK();
                    rut.ShowDialog();                
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
