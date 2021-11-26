using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TestITrade.Business;
using TestITrade.Model;
using TestITrade.Model.Category;
using TestITrade.Repository;

namespace TestITrade
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TradeCategoryFilter> lTradeCategoryFilter = new List<TradeCategoryFilter>();
            CrudTradeCategoryFilter crudTradeCategoryFilter = new CrudTradeCategoryFilter();
            lTradeCategoryFilter.Add(crudTradeCategoryFilter.add("EXPIRED", 30, 0, null));
            lTradeCategoryFilter.Add(crudTradeCategoryFilter.add("HIGHRISK", 0, 1000000, "Private"));
            lTradeCategoryFilter.Add(crudTradeCategoryFilter.add("MEDIUMRISK", 0, 1000000, "Public"));


            string referenceDate;
            DateTime dtreferenceDate;
            Console.Write("Enter the reference date (mm/dd/yyyy):");
            referenceDate = Console.ReadLine();
            dtreferenceDate = DateTime.ParseExact(referenceDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            string records;
            Console.Write("Enter the number of records:");
            records = Console.ReadLine();

            List<Trade> lTrade = new List<Trade>();
            CrudTrade crudTrade = new CrudTrade();

            int intRecords = int.Parse(records);
            string recordReturn;
            string clientSector;
            DateTime nextPaymentDate;
            double value;

            for (int i = 1; i <= intRecords; i++)
            {
                Console.Write("Enter the record [" + i.ToString() + "/ " + records + "]:" );
                recordReturn = Console.ReadLine();

                value = Double.Parse(recordReturn.Split(' ')[0]);
                clientSector = recordReturn.Split(' ')[1].Trim();
                nextPaymentDate = DateTime.ParseExact(recordReturn.Split(' ')[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);

                lTrade.Add( crudTrade.add( clientSector, nextPaymentDate, value) );
                Console.WriteLine();
            }

            TradeFilter tradeFilter = new TradeFilter();
            foreach (Trade trade in lTrade)
            {
                Console.WriteLine(tradeFilter.GetCategory( trade, dtreferenceDate, lTradeCategoryFilter) );
            }


            Console.ReadKey();

        }
    }
}
