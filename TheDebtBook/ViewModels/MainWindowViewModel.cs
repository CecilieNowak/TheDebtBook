using System;
using System.Collections.ObjectModel;

using System.Windows;
using Microsoft.Win32;

using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Views;
using TheDebtBook.Models;



namespace TheDebtBook.ViewModels
{
    /// <summary>
    /// Interaction logic for MainWindowViewModel.xaml
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {

        }

        private DelegateCommand addButtonCommand;

        public DelegateCommand AddButtonCommand =>
            addButtonCommand ?? (addButtonCommand = new DelegateCommand(ExecuteAddCommand));

        void ExecuteAddCommand()
        {
            var addNewDebtor = new Debtor();

            var viewmodel = new AddDebtorViewModel(addNewDebtor);
 
            var dialog = new AddDebtorView()
            {
                DataContext = viewmodel
            };
            if (dialog.ShowDialog() == true)
            {
                //_debtors.Add(addNewDebtor);
                //_currentDebtor = addNewDebtor;
                MessageBox.Show("vre");
            }
        }
    }
}
