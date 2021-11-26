using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            //Declare variables
            List<Trade> lTrade = new List<Trade>();
            CrudTrade crudTrade = new CrudTrade();
            string recordReturn;
            string clientSector;
            DateTime nextPaymentDate;
            double value;
            bool isPEP = false;
            List<TradeCategoryFilter> lTradeCategoryFilter = new List<TradeCategoryFilter>();
            CrudTradeCategoryFilter crudTradeCategoryFilter = new CrudTradeCategoryFilter();

            //Add Category and CategoryFilter
            lTradeCategoryFilter.Add(crudTradeCategoryFilter.add("EXPIRED", 30, 0, null));
            lTradeCategoryFilter.Add(crudTradeCategoryFilter.add("HIGHRISK", 0, 1000000, "Private"));
            lTradeCategoryFilter.Add(crudTradeCategoryFilter.add("MEDIUMRISK", 0, 1000000, "Public"));
            lTradeCategoryFilter.Add(crudTradeCategoryFilter.add("PEP", 0, 0, "", true)); // Question 2:Category PEP

            //Get parameter reference Date
            string referenceDate;
            DateTime dtreferenceDate;
            Console.Write("Enter the reference date (mm/dd/yyyy):");
            referenceDate = Console.ReadLine();
            dtreferenceDate = DateTime.ParseExact(referenceDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            //Get parameter number of records
            string records;
            Console.Write("Enter the number of records:");
            records = Console.ReadLine();
            int intRecords = int.Parse(records);

            //Get trades
            for (int i = 1; i <= intRecords; i++)
            {
                Console.Write("Enter the record [" + i.ToString() + "/ " + records + "]:" );
                recordReturn = Console.ReadLine();

                value = Double.Parse(recordReturn.Split(' ')[0]);
                clientSector = recordReturn.Split(' ')[1].Trim();
                nextPaymentDate = DateTime.ParseExact(recordReturn.Split(' ')[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                
                if (recordReturn.Split(' ').Count() == 4) // Question 2:Category PEP
                    isPEP = bool.Parse( recordReturn.Split(' ')[3].Trim() );

                lTrade.Add( crudTrade.add( clientSector, nextPaymentDate, value, isPEP) );
            }

            //Print result
            TradeFilter tradeFilter = new TradeFilter();
            Console.WriteLine();
            foreach (Trade trade in lTrade)
            {
                Console.WriteLine(tradeFilter.GetCategory( trade, dtreferenceDate, lTradeCategoryFilter) );
            }

            Console.ReadKey();

        }
    }
}
