using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace TheDebtBook.Models
{
    public class Debt : BindableBase
    {
        private int _value;
        private string _date;

        public Debt()
        {
            _date = DateTime.Now.ToString();
        }

        public Debt (int value, string date, int debtValue)
        {
            _value = value;
            _date = date;
        }

        public int DebtValue
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
    }
}
