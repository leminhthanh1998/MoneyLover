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
        //class CustomerDao
        //{
        //    public static ObservableCollection<CIMAST> GetCustomers()
        //    {
        //        string sql = @"SELECT * FROM [Customers]";
        //        return AdoData.ReadList(sql, MakeDataObject);
        //    }
        //}
            public DanhSachSTK()
        {
            InitializeComponent();
            using (var db = new MoneyEntity())
            {

                ObservableCollection<CIMAST> samdata = new ObservableCollection<CIMAST>();
                var lst = db.CIMASTs.ToList();
                // samdata.Add(lst);

                for (int i = 0; i < lst.Count(); i++)
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
                //ok r

                ListCollectionView collection = new ListCollectionView(samdata);
                collection.GroupDescriptions.Add(new PropertyGroupDescription("BANK"));
                dgrDangKy.ItemsSource = collection;
                
                var sum = db.CIMASTs.Select(c => c.DEPOSITAMT).Sum();
                var count = db.CIMASTs.Count();
                txtSum.Text = sum.ToString() + "(" + count+ "sổ)";
               
            }
        }


        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
            {

                if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                    App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
            }
            ThemSTK t = new ThemSTK();
            t.ShowDialog();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
            {

                if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                    App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
            }
            SuaSTK sua = new SuaSTK();
            sua.ShowDialog();
        }

        private void btnTatToan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuiThem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRut_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
            {

                if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                    App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
            }
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
