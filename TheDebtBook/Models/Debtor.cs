using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using TheDebtBook.Models;

namespace TheDebtBook.Models
{
    public class Debtor : BindableBase
    {
        private string _name;
        private int _value;
        private int _totalDebt;
        
        public Debtor()
        {


        }

        public Debtor(string name, int value, int totalDebt)
        {
            _name = name;
            _totalDebt = totalDebt;
            _value = value;
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }

        }

        public int Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }

        }

        public int TotalDebt
        {
            get { return _totalDebt; }
            set { SetProperty(ref _totalDebt, value); }

        }
    }
}
