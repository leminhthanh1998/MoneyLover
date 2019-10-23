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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDK_Click(object sender, RoutedEventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();

        }

        private void btnDN_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MoneyEntity())
            {

                var checkemail = db.users.Where(x => x.email == txbEmail.Text).Count();
                if (checkemail != 0)
                {
                    var timemail = db.users.Where(x => x.email == txbEmail.Text).Single();
                    if (txbEmail.Text == timemail.email && txbPass.Password.ToString() == timemail.pass)
                    {

                        for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
                        {

                            if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                                App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
                        }

                        DanhSachSTK stk = new DanhSachSTK();
                        stk.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show("Email khong dung hoac chua dang ky", "Error", MessageBoxButton.OK);

                }
            }

            //check mail
          

          
            }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool CheckPassword(string pass)
        {
            //min 6 chars, max 12 chars
            if (pass.Length < 8 || pass.Length > 12)
                return false;

            //No white space
            if (pass.Contains(" "))
                return false;

            //At least 1 upper case letter
            if (!pass.Any(char.IsUpper))
                return false;

            //At least 1 lower case letter
            if (!pass.Any(char.IsLower))
                return false;

            //No two similar chars consecutively
            for (int i = 0; i < pass.Length - 1; i++)
            {
                if (pass[i] == pass[i + 1])
                    return false;
            }

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

        private void txbPass_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txbPass_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void txbPass_MouseLeave(object sender, MouseEventArgs e)
        {
           
        }

        private void txbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txbPass.Password.Length > 0)
                ImgShowHide.Visibility = Visibility.Visible;
            else
                ImgShowHide.Visibility = Visibility.Hidden;
        }

        private void ImgShowHide_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            txtVisiblePasswordbox.Visibility = Visibility.Hidden;
            txbPass.Visibility = Visibility.Visible;
            txbPass.Focus();
        }

        private void ImgShowHide_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            txtVisiblePasswordbox.Visibility = Visibility.Visible;
            txbPass.Visibility = Visibility.Hidden;
            txtVisiblePasswordbox.Text = txbPass.Password;
        }

        private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
        {
            txtVisiblePasswordbox.Visibility = Visibility.Hidden;
            txbPass.Visibility = Visibility.Visible;
            txbPass.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // ImgShowHide.Source = new BitmapImage(new Uri("pack://application:,,,/AssemblyName;component/img/Hide.jpg", UriKind.Relative));
        }
    }
}


