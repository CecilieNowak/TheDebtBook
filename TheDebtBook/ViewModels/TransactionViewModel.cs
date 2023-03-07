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
        private ObservableCollection<Debt> _debts;
        private Debtor _currentDebtor;

        public TransactionViewModel() {}

        public TransactionViewModel(Debtor debtor)
        {
            _debts = new ObservableCollection<Debt>();
            CurrentDebtor = debtor;
            AddValueToList();
            CurrentDebtor.Value = 0;
        }

        private void AddValueToList()
        {
            foreach (var item in CurrentDebtor.TransactionDebts)
            {
                _debts.Add(new Debt() {Date = item.Date, DebtValue = item.DebtValue});
            }
        }

        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set
            {
                SetProperty(ref _currentDebtor, value);
            }
        }

        public ObservableCollection<Debt> Debts
        {
            get { return _debts; }
            set { SetProperty(ref _debts, value); }
        }

        private DelegateCommand? _addValueCommand;

        public DelegateCommand? AddValueCommand =>
            _addValueCommand ?? (_addValueCommand = new DelegateCommand(AddValueCommandExecute));

        private void AddValueCommandExecute()
        {
            Debts.Add(new Debt() { DebtValue = CurrentDebtor.Value, Date = DateTime.Now.ToShortDateString()});
            CurrentDebtor.TransactionDebts.Add(new Debt() { DebtValue = CurrentDebtor.Value, Date = DateTime.Now.ToShortDateString() });
            CurrentDebtor.Value = 0;
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
