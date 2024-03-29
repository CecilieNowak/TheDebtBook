﻿using System;
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
        private int _debtValue;
        private string _date;

        public Debt()
        {
            _date = DateTime.Now.ToShortDateString();
        }

        public Debt (int value, string date)
        {
            _debtValue = value;
            _date = date;
        }

        public int DebtValue
        {
            get { return _debtValue; }
            set { SetProperty(ref _debtValue, value); }
        }

        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
    }
}
