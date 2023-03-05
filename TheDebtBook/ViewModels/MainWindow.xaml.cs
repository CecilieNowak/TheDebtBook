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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Views;
using TheDebtBook.Models;



namespace TheDebtBook.ViewModels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BindableBase
    {
        public MainWindow()
        {

        }

        private DelegateCommand addButtonCommand;

        public DelegateCommand AddButtonCommand =>
            addButtonCommand ?? (addButtonCommand = new DelegateCommand(ExecuteAddCommand));

        void ExecuteAddCommand()
        {
            var addNewDeptor = new Debtor();

            var vm = new AddDebtorViewModel();
            MessageBox.Show("vre");
            var dialog = new AddDebtorView()
            {
                DataContext = vm
            };
            if (dialog.ShowDialog() == true)
            {
                //_debtors.Add(addNewDeptor);
                //_currentDebtor = addNewDeptor;
                MessageBox.Show("vre");
            }
        }
    }
}
