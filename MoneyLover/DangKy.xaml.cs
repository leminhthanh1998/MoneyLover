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
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : Window
    {
        public DangKy()
        {
            InitializeComponent();
          
        }

        private void btnDK_Click(object sender, RoutedEventArgs e)
        {
            
            using (var db = new MoneyEntity())
            {

                if (IsValidEmail(txbEmail.Text) == true)
                {
                    if (CheckPassword(txbPass.Password.ToString()) == true)
                    {
                        User user = new User()
                        {
                            email = txbEmail.Text,
                            pass = txbPass.Password.ToString()
                        };

                        db.users.Add(user);
                        db.SaveChanges();
                        MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButton.OK);
                        for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
                        {

                            if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                                App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
                        }
                        DangNhap dn = new DangNhap();
                        dn.ShowDialog();
                    }
                }
               
            }
        }



        //check mail
       public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("Mail không được để trống", "Thông báo", MessageBoxButton.OK);
                return false;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Mail không đúng định dạng ","Thôn báo", MessageBoxButton.OK);
                return false;
            }
        }

        // check pass
        //public static class PasswordChecker
        //{
        public static bool CheckPassword(string pass)
        {
            //min 8 chars, max 12 chars
            if (pass.Length < 8 || pass.Length > 12)
            {
                MessageBox.Show("Password không dài quá 12 ký tự và phải trên 8 ký tự", "Error");
                return false;
            }


            //No white space
            if (pass.Contains(" "))
            {
                MessageBox.Show("Password không được có khoảng trống", "Error");
                return false;
            }


            //At least 1 upper case letter
            if (!pass.Any(char.IsUpper))
            {
                MessageBox.Show("Password có ít nhất 1 ký tự viết hoa", "Error");
                return false;
            }


            //At least 1 lower case letter
            if (!pass.Any(char.IsLower))
            {
                MessageBox.Show("Password có ít nhất 1 ký tự viết thường", "Error");
                return false;
            }

            //No two similar chars consecutively
            //for (int i = 0; i < pass.Length - 1; i++)
            //{
            //    if (pass[i] == pass[i + 1])
            //        MessageBox.Show("Password không chưa 2 ký tự giống nhau", "Error");
            //    return false;
            //}

            //At least 1 special char
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            foreach (char c in specialCharactersArray)
            {
                if (pass.Contains(c))
                    return true;
            }
            return false;
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
            {
                if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                    App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
            }
            MainWindow dn = new MainWindow();
            dn.ShowDialog();
        }
    }

}
