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
using TheDebtBook.ViewModels;

namespace TheDebtBook.Views
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : Window
    {
        public TransactionView()
        {
            InitializeComponent();
        }

        private void AddValueTxb_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAddValue.Focus();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as TransactionViewModel;
            DialogResult = true;
        }
    }
}
