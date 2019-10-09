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
    /// Interaction logic for ThemSTK.xaml
    /// </summary>
    public partial class ThemSTK : Window
    {
        public ThemSTK()
        {
            InitializeComponent();
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            using (var db = new MoneyEntity())
            {
               
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
