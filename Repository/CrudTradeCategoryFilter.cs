using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestITrade.Model.Category;

namespace TestITrade.Repository
{
    public class CrudTradeCategoryFilter
    {
        public TradeCategoryFilter add(string name, int filterExpiredDate, double filterValueLimit, string filterClientSector, bool IsPoliticallyExposed) // Question 2:Category PEP
        {
            TradeCategoryFilter tradeCategoryFilter = new TradeCategoryFilter();

            tradeCategoryFilter.FilterClientSector = filterClientSector;
            tradeCategoryFilter.FilterValueLimit = filterValueLimit;
            tradeCategoryFilter.FilterExpiredDate = filterExpiredDate;
            tradeCategoryFilter.Name = name;
            tradeCategoryFilter.IsPoliticallyExposed = IsPoliticallyExposed;

            return tradeCategoryFilter;
        }
        public TradeCategoryFilter add( string name, int filterExpiredDate, double filterValueLimit, string filterClientSector )
        {
            TradeCategoryFilter tradeCategoryFilter = new TradeCategoryFilter();

            tradeCategoryFilter.FilterClientSector = filterClientSector;
            tradeCategoryFilter.FilterValueLimit = filterValueLimit;
            tradeCategoryFilter.FilterExpiredDate = filterExpiredDate;
            tradeCategoryFilter.Name = name;
            tradeCategoryFilter.IsPoliticallyExposed = false;

            return tradeCategoryFilter;
        }

        public void remove ( ref List<TradeCategoryFilter> lTradeCategoryFilter, string name )
        {
            var result = find(lTradeCategoryFilter, name);
            if (result != null)
            {
                lTradeCategoryFilter.Remove(result);
            }
        }

        public void modify( ref List<TradeCategoryFilter> lTradeCategoryFilter, string name, int filterExpiredDate, double filterValueLimit, string filterClientSector )
        {
            var result = find(lTradeCategoryFilter, name);
            if (result != null)
            {
                result.FilterClientSector = filterClientSector;
                result.FilterExpiredDate = filterExpiredDate;
                result.FilterValueLimit = filterValueLimit;
                result.Name = name;
            }
        }

        private TradeCategoryFilter find(List<TradeCategoryFilter> lTradeCategoryFilter, string name)
        {
            return lTradeCategoryFilter.Where(n => n.Name == name).FirstOrDefault();
             
        }
    }
}
