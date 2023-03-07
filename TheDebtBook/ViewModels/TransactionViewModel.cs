using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    internal class TransactionViewModel : BindableBase
    {

        public TransactionViewModel() { }

        public TransactionViewModel(Debtor debtor)
        {
            _debts = new ObservableCollection<Debt>();

            CurrentDebtor = debtor;
            
            AddValueToList();

            CurrentDebtor.Value = 0;
        }

        private ObservableCollection<Debt> _debts;
        public ObservableCollection<Debt> DebtsCollection
        {
            get { return _debts; }
            set { SetProperty(ref _debts, value); }
        }

        Debtor _currentDebtor;

        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set
            {
                SetProperty(ref _currentDebtor, value);
            }
        }

        private DelegateCommand? _addValueCommand;
        public DelegateCommand? AddValueCommand =>
            _addValueCommand ?? (_addValueCommand = new DelegateCommand(AddValueCommandExecute));

        private void AddValueCommandExecute()
        {

            DebtsCollection.Add(new Debt() { DebtValue = CurrentDebtor.Value, Date = DateTime.Now.ToShortDateString() });

            CurrentDebtor.TransactionDebts.Add(new Debt() { DebtValue = CurrentDebtor.Value, Date = DateTime.Now.ToShortDateString() });

            CurrentDebtor.Value = 0;
        }


        private void AddValueToList()
        {
            foreach (var item in CurrentDebtor.TransactionDebts)
            {
                _debts.Add(new Debt() { Date = item.Date, DebtValue = item.DebtValue });
            }
        }


        private DelegateCommand? _closeCommand;
        public DelegateCommand? CloseCommand =>
            _closeCommand ?? (_closeCommand = new DelegateCommand(CloseCommandExecute));

        private void CloseCommandExecute()
        {
            _currentDebtor.TotalDebt = _debts.Sum(x => x.DebtValue);
        }

    }
}
