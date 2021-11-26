using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestITrade.Model;

namespace TestITrade.Repository
{
    public class CrudTrade
    {
        public Trade add(string clientSector, DateTime nextPaymentDate, double value, bool IsPoliticallyExposed) // Question 2:Category PEP
        {
            return new Trade( value, clientSector, nextPaymentDate, IsPoliticallyExposed) ;
           
        }
        public Trade add(string clientSector, DateTime nextPaymentDate, double value)
        {
            return new Trade(value, clientSector, nextPaymentDate, false);

        }
    }
}
