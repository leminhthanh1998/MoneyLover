using MoneyLover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SuaSTK.xaml
    /// </summary>
    public partial class SuaSTK : Window
    {
        public SuaSTK()
        {
            InitializeComponent();
            using (var db = new MoneyEntity())
            {
                txtNganHang.ItemsSource = db.bANKs.ToList();
                txtNganHang.Items.Refresh();
                txtNganHang.DisplayMemberPath = "Name";
                txtNganHang.SelectedValuePath = "Name";
                var stk = db.CIMASTs.Where(x => x.ACCTNO == DanhSachSTK.maSTK).Single();
                txbSTK.Text = stk.ACCTNO.ToString();
                txtNganHang.Text = stk.BANK.ToString();
                txbSotien.Text = stk.DEPOSITAMT.ToString();
                txbLai.Text = stk.RATE.ToString();
                txbLaiKTH.Text = stk.NPTERM.ToString();
                txtNgayGui.Text = stk.FRDATE.ToString();
                cbKhiDH.Text = stk.KhiDenHan.ToString();

                if (stk.KhiDenHan.ToString() == "Tái tục gốc")
                {
                    cbKhiDH.SelectedIndex = 1;
                }
                else
                {
                    cbKhiDH.Text = stk.KhiDenHan.ToString();
                }
                cbTraLai.Text = stk.TraLai.ToString();

                if (stk.TERM == 0)
                {
                    cbKH.Text = "không kỳ hạn";
                }
                else if (stk.TERM == 12)
                {
                    cbKH.Text = "12";
                }
                else if (stk.TERM == 1)
                {
                    cbKH.Text = "1";
                }
                else if (stk.TERM == 6)
                {
                    cbKH.Text = "6";
                }
                else if (stk.TERM == 3)
                {
                    cbKH.Text = "3";
                }

            }
        }

        private void btnSave_Click(object sender, KeyEventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cbKH.SelectedItem;
            ComboBoxItem typeItem1 = (ComboBoxItem)cbKhiDH.SelectedItem;
            ComboBoxItem typeItem2 = (ComboBoxItem)cbTraLai.SelectedItem;

            using (var db = new MoneyEntity())
            {
                MessageBoxResult result = MessageBox.Show("Lưu thay đổi ?", "Thông báo", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (cbKH.Text != "")
                    {
                        if (txtNganHang.Text != "")
                        {
                            if (txbLai.Text != "")
                            {
                                if (txbSotien.Text != "")
                                {
                                    if (cbTraLai.Text != "")
                                    {
                                        if (cbKhiDH.Text != "")
                                        {

                                            if (DateTime.Parse(txtNgayGui.Text) <= DateTime.Now)
                                            {
                                                if (double.TryParse(txbSotien.Text, out double sotien))
                                                    if (sotien > 1000000)
                                                    {
                                                        var ci = db.CIMASTs.Where(x => x.ACCTNO == DanhSachSTK.maSTK).Single();
                                                        ci.DEPOSITAMT = double.Parse(txbSotien.Text);
                                                        ci.RATE = double.Parse(txbLai.Text);
                                                        ci.BANK = txtNganHang.Text;
                                                        ci.FRDATE = DateTime.Parse(txtNgayGui.Text);
                                                        ci.KhiDenHan = typeItem1.Content.ToString();
                                                        ci.Balance = ci.DEPOSITAMT;
                                                        //lãi không kỳ hạn
                                                        if (txbLaiKTH.Text == null || txbLaiKTH.Text == "")
                                                        {
                                                            ci.NPTERM = 0.5;
                                                        }
                                                        else
                                                        {
                                                            ci.NPTERM = double.Parse(txbLaiKTH.Text);



                                                        }
                                                        ci.TERM = int.Parse(typeItem.Tag.ToString());
                                                        ci.TraLai = typeItem2.Content.ToString();

                                                       // db.CIMASTs.Add(ci);
                                                        db.SaveChanges();
                                                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK);
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
                                                        MessageBox.Show("Số tiền >= 1.000.000", "Error", MessageBoxButton.OK);
                                                    }
                                                else
                                                {
                                                    MessageBox.Show("Vui lòng nhập số", "Error", MessageBoxButton.OK);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Ngày gửi <= ngày hiện tại", "Error", MessageBoxButton.OK);
                                            }
                                        }
                                        else { MessageBox.Show("Vui lòng khi đến hạng", "Error", MessageBoxButton.OK); }
                                    }
                                    else { MessageBox.Show("Vui lòng chọn trả lãi", "Error", MessageBoxButton.OK); }
                                }
                                else
                                {
                                    MessageBox.Show("Không được để trống ô số tiền", "Error", MessageBoxButton.OK);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không được để trống ô lãi suất", "Error", MessageBoxButton.OK);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Vui lòng chọn ngân hàng", "Error", MessageBoxButton.OK);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn kỳ hạn", "Error", MessageBoxButton.OK);
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    Close();
                }
            }
        }

        private void btnBank_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MoneyEntity())
            {
                Banks bank = new Banks();
                bank.ShowDialog();
                var nganhang = (BANKS)txtNganHang.Items[0];
                txtNganHang.ItemsSource = db.bANKs.ToList();
            }
        }
    }
}


