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

        ObservableCollection<Debtor> _debtors;

        public ObservableCollection<Debtor> Debtors
        {
            get { return _debtors; }
            set
            {
                SetProperty(ref _debtors, value);
            }
        }

        string fileName = "";
        public string Filename
        {
            get { return fileName; }
            set
            {
                SetProperty(ref fileName, value);
            }
        }

        private bool dirty = false;
        public bool Dirty
        {
            get { return dirty; }
            set
            {
                SetProperty(ref dirty, value);
            }
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

        private DelegateCommand? newFileCommand;

        public DelegateCommand NewFileCommand =>
            newFileCommand ?? (newFileCommand = new DelegateCommand(NewFileCommandExecute));

        void NewFileCommandExecute()
        {
            MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost, are you sure want to continue?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Debtors.Clear();
                Filename = string.Empty;
                Dirty = false;
                
            }
        }
    }
}
