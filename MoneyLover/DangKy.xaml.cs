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
            using (var db = new MoneyEntity())
            {

            }
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
                        MessageBox.Show("Dang ky thanh cong", "Error", MessageBoxButton.OK);
                        for (int intCounter = App.Current.Windows.Count - 1; intCounter > -1; intCounter--)
                        {

                            if (App.Current.Windows[intCounter].Name != "Main_Window_wind")
                                App.Current.Windows[intCounter].Visibility = System.Windows.Visibility.Hidden;
                        }
                        DangNhap dn = new DangNhap();
                        dn.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Nhap sai dinh dang password", "Error", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Nhap sai dinh dang email", "Error", MessageBoxButton.OK);
                }
            }
        }

 

        //check mail
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

        // check pass
        //public static class PasswordChecker
        //{
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
        }
    
}
