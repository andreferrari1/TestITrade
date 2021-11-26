using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestITrade.Model;

namespace TestITrade.Repository
{
    public class CrudTrade
    {
        public Trade add(string clientSector, DateTime nextPaymentDate, double value)
        {
            return new Trade( value, clientSector, nextPaymentDate) ;
           
        }
    }
}
