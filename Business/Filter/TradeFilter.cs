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
           
            TradeCategoryFilter categoryResult = null;

            //0. Question 2: PEP
            if ( trade.IsPoliticallyExposed )
                categoryResult = categoryFilter.Where(d => d.IsPoliticallyExposed == trade.IsPoliticallyExposed).FirstOrDefault();

            //1. EXPIRED: Trades whose next payment date is late by more than XXXXX days based on a reference date which will be given.
            if (categoryResult == null)
            {
                categoryResult = categoryFilter.Where(d => d.FilterExpiredDate < ((referenceDate - trade.NextPaymentDate ).TotalDays) && d.FilterExpiredDate > 0).FirstOrDefault();
            }
            else
            {
                return categoryResult.Name;
            }

            //2.HIGHRISK: Trades with value greater than 1,000,000 and client from Private Sector.
            if ( categoryResult == null )
            {
                categoryResult = categoryFilter.Where(d => d.FilterValueLimit < trade.Value && trade.ClientSector == d.FilterClientSector && "Private" == trade.ClientSector).FirstOrDefault();
            }
            else
            {
                return categoryResult.Name;
            }

            //3. MEDIUMRISK: Trades with value greater than 1,000,000 and client from Public Sector.
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


