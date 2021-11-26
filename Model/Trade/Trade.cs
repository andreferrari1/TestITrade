using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestITrade.Model
{
    public class Trade : ITrade
    {
        private double value;
        private string clientSector;
        private DateTime nextPaymentDate;
        private bool isPoliticallyExposed;

        public Trade(double _value, string _clientSector, DateTime _nextPaymentDate)
        {
            value = _value;
            clientSector = _clientSector;
            nextPaymentDate = _nextPaymentDate;
            isPoliticallyExposed = false;
        }

        public Trade(double _value, string _clientSector, DateTime _nextPaymentDate, bool _isPoliticallyExposed) // Question 2:Category PEP
        {
            value = _value;
            clientSector = _clientSector;
            nextPaymentDate = _nextPaymentDate;
            isPoliticallyExposed = _isPoliticallyExposed;
        }

        public double Value
        {
            get { return value; }
        }

        public string ClientSector
        {
            get { return clientSector; }
        }

        public DateTime NextPaymentDate
        {
            get { return nextPaymentDate; }
        }


        public bool IsPoliticallyExposed
        {
            get { return isPoliticallyExposed; }
        }
        

    }
}
