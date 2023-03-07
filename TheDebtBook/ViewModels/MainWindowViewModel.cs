using System;
using System.Collections.ObjectModel;

using System.Windows;
using Microsoft.Win32;

using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Views;
using TheDebtBook.Models;
using System.IO;
using TheDebtBook.Data;

namespace TheDebtBook.ViewModels
{
    /// <summary>
    /// Interaction logic for MainWindowViewModel.xaml
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        private string filePath = "";
        public MainWindowViewModel()
        {
            _debtors = new ObservableCollection<Debtor>();
        }

        private Debtor _currentDebtor;
        private ObservableCollection<Debtor> _debtors;

        public ObservableCollection<Debtor> Debtors
        {
            get { return _debtors; }
            set { SetProperty(ref _debtors, value); }
        }

        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set
            {
                SetProperty(ref _currentDebtor, value);

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
               _debtors.Add(addNewDebtor);
               _currentDebtor = addNewDebtor;
               
            }
        }

        private DelegateCommand? showDebtCommand;

        public DelegateCommand? ShowDebtCommand =>
            showDebtCommand ?? (showDebtCommand = new DelegateCommand(ExecuteShowDebtCommand));

        void ExecuteShowDebtCommand()
        {
            var localDebtor = CurrentDebtor.Clone();
            var vm = new TransactionViewModel(localDebtor);

            var dialog = new TransactionView()
            {
                DataContext = vm,
                Owner = Application.Current.MainWindow

            };
            if (dialog.ShowDialog() == true)
            {
                _currentDebtor.TotalDebt = localDebtor.TotalDebt;
                _currentDebtor.TransactionDebts = localDebtor.TransactionDebts;
            }
        }

        #region File 
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

        private DelegateCommand? saveAsCommand;

        public DelegateCommand SaveAsCommand =>
            saveAsCommand ?? (saveAsCommand = new DelegateCommand(SaveAsCommandExecute));

        void SaveAsCommandExecute()
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                //Sets the filetype 
                Filter = "The debt book documents|*.deb|All Files|*.*",
                DefaultExt = "deb"
            };

            if (filePath == "")
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dlg.InitialDirectory = Path.GetDirectoryName(filePath);

            if (dlg.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dlg.FileName;
                Filename = Path.GetFileName(filePath);

                try
                {
                    FileData.SaveFile(filePath, Debtors);
                    Dirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private DelegateCommand? openFileCommand;

        public DelegateCommand OpenFileCommand =>
            openFileCommand ?? (openFileCommand = new DelegateCommand(OpenFileCommandExecute));

        void OpenFileCommandExecute()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "The debt book documents|*.deb|All Files|*.*",
                DefaultExt = "deb"
            };
            if (filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if(dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                Filename = Path.GetFileName(filePath);
                try
                {
                    Debtors = FileData.ReadFile(filePath);
                    Dirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private DelegateCommand? saveFileCommand;
        public DelegateCommand SaveFileCommand =>
            saveFileCommand ?? (saveFileCommand = new DelegateCommand(SaveFileCommandExecute, SaveFileCommandCanExecute)
            .ObservesProperty(() => Debtors.Count));

        private void SaveFileCommandExecute()
        {
            try
            {
                FileData.SaveFile(filePath, Debtors);
                Dirty = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool SaveFileCommandCanExecute()
        {
            return (fileName != "") && (Debtors.Count > 0);
        }
        #endregion

    }
}
