using Prism.Mvvm;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    /// <summary>
    /// Interaction logic for AddDebtorViewModel.xaml
    /// </summary>
    public partial class AddDebtorViewModel : BindableBase
    {
        private Debtor _currentDebtor;
        public AddDebtorViewModel(Debtor currentDebtor)
        {
            _currentDebtor = currentDebtor;
        }
    }
}
