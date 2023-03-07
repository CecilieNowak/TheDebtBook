using System;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    /// <summary>
    /// Interaction logic for AddDebtorViewModel.xaml
    /// </summary>
    public partial class AddDebtorViewModel : BindableBase
    {
        public AddDebtorViewModel(Debtor currentDebtor)
        {
            CurrentDebtor = currentDebtor;
        }

        private Debtor _currentDebtor;

        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set
            {
                SetProperty(ref _currentDebtor, value);
            }
        }

        private DelegateCommand saveButtonCommand;

        public DelegateCommand SaveButtonCommand =>
            saveButtonCommand ?? (saveButtonCommand = new DelegateCommand(ExecuteSaveButtonCommand, canSaveButtonCommand)
                .ObservesProperty(() => CurrentDebtor.Name).ObservesProperty(() => CurrentDebtor.Value));

        bool canSaveButtonCommand()
        {
            return ValidInput;
        }

        void ExecuteSaveButtonCommand()
        {
            CurrentDebtor.TransactionDebts.Add(new Debt() {DebtValue = CurrentDebtor.Value,Date = DateTime.Now.ToShortDateString()});
            CurrentDebtor.TotalDebt = CurrentDebtor.TransactionDebts.Sum(x => x.DebtValue);
        }

        public bool ValidInput
        {
            get
            {
                bool validInput = true; //TODO Behøver den sættes til true?
                if (string.IsNullOrWhiteSpace(CurrentDebtor.Name))
                {
                    validInput = false;
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(CurrentDebtor.Value)))
                {
                    validInput = false;
                }
                return validInput;
            }
        }
    }
}
