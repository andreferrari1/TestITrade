using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestITrade.Model;
using TestITrade.Model.Category;

namespace TestITrade.Business
{
    public class TradeFilter
    {
        public string GetCategory( Trade trade, DateTime referenceDate, List<TradeCategoryFilter> categoryFilter)
        {
            //1.
            TradeCategoryFilter categoryResult;
            categoryResult = categoryFilter.Where(d => d.FilterExpiredDate < ((referenceDate - trade.NextPaymentDate ).TotalDays) && d.FilterExpiredDate > 0).FirstOrDefault();

            //2.
            if ( categoryResult == null )
            {
                categoryResult = categoryFilter.Where(d => d.FilterValueLimit < trade.Value && trade.ClientSector == d.FilterClientSector && "Private" == trade.ClientSector).FirstOrDefault();
            }
            else
            {
                return categoryResult.Name;
            }

            //3.
            if (categoryResult == null )
            {
                categoryResult = categoryFilter.Where(d => d.FilterValueLimit < trade.Value && trade.ClientSector == d.FilterClientSector && "Public" == trade.ClientSector).FirstOrDefault();
            }
            else
            {
                return categoryResult.Name;
            }

            return categoryResult.Name;
        }
    }
}


