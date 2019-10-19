using MoneyLover.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DanhSachSTK.xaml
    /// </summary>
    public partial class DanhSachSTK : Window
    {
        public static int? maSTK;
       
            public DanhSachSTK()
        {
            InitializeComponent();
            using (var db = new MoneyEntity())
            {

                ObservableCollection<CIMAST> samdata = new ObservableCollection<CIMAST>();
                var lst = db.CIMASTs.ToList();
                List<CIMAST> lstTatToan = new List<CIMAST>();
                // samdata.Add(lst);

                for (int i = 0; i < lst.Count(); i++)
                {
                    if (lst[i].STT !="Tất toán")
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

                    samdata.Add(ci);
                }
                }
                //ok r

                ListCollectionView collection = new ListCollectionView(samdata);
                collection.GroupDescriptions.Add(new PropertyGroupDescription("BANK"));
                dgrDangKy.ItemsSource = collection;
                
               
                for (int i = 0; i < lst.Count(); i++)
                {
                    if(lst[i].STT=="Tất toán")
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
                        lstTatToan.Add(ci);
                    }
                }

                dgrTattoan.ItemsSource = lstTatToan.OrderByDescending(x=>x.FRDATE);

                var sum = db.CIMASTs.Where(x=>x.STT !="Tất toán").Select(c => c.DEPOSITAMT).Sum();
                var count = db.CIMASTs.Where(x => x.STT != "Tất toán").Count();
                var countTT = db.CIMASTs.Where(x => x.STT == "Tất toán").Count();
                txtSum.Text = sum.ToString() + "(" + count + "sổ)";
                txtTatToan.Text = "Đã tất toán" + "(" + countTT + "sổ)";

            }
        }


        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
           
            ThemSTK t = new ThemSTK();
            t.ShowDialog();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            SuaSTK sua = new SuaSTK();
            sua.ShowDialog();
        }

        private void btnTatToan_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn tất toán tài khoản", "Thông báo", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new MoneyEntity())
                {
                    var stk = db.CIMASTs.Where(x => x.ACCTNO == DanhSachSTK.maSTK).Single();
                    int ngay = stk.TERM * 30;
                    if (DateTime.Now >= stk.FRDATE.AddDays(ngay))
                    {
                        stk.STT = "Tất toán";
                        db.SaveChanges();

                        MessageBox.Show("Tất toán thành công", "Thông báo", MessageBoxButton.OK);
                        for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
                        {

                            if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                                App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
                        }
                        DanhSachSTK dn = new DanhSachSTK();
                        dn.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Chưa đến hạn", "Error", MessageBoxButton.OK);
                    }
                   
                }
            }
        }

        private void btnGuiThem_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MoneyEntity())
            {
                var stk = db.CIMASTs.Where(x => x.ACCTNO == DanhSachSTK.maSTK).Single();
                if (stk.TERM == 0)
                {
                    GuiThem gui = new GuiThem();
                    gui.ShowDialog();
                }
                else 
                {
                    if(stk.KhiDenHan== "Tái tục gốc và lãi" || stk.KhiDenHan== "Tái tục gốc")
                    {
                        int ngay = stk.TERM * 30;
                        if (DateTime.Now >= stk.FRDATE.AddDays(ngay))
                        {
                            GuiThem gui = new GuiThem();
                            gui.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Chưa đến hạn gửi", "Error", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sổ này không thể gửi thêm tiền", "Error", MessageBoxButton.OK);
                    }
                   
                }
            }
            
        }

        private void btnRut_Click(object sender, RoutedEventArgs e)
        {
            
            RutTien rut = new RutTien();
            rut.ShowDialog();
        }

        private void dgrDangKy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int? soTK = (dgrDangKy.SelectedItem as CIMAST).ACCTNO;
            if (soTK != null)
            {
                maSTK = soTK;
            }

            else
            {
                return;
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DgrDangKy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
