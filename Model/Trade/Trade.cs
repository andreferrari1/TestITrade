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

       public Trade(double _value, string _clientSector, DateTime _nextPaymentDate)
        {
            value = _value;
            clientSector = _clientSector;
            nextPaymentDate = _nextPaymentDate;
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

    }
}
