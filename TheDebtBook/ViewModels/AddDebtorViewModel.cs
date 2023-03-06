using System;
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
