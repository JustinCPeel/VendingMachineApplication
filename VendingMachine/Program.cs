using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> denominations = new Dictionary<int, int>
            {
                { 1, 25 },
                { 5, 5 },
                { 10, 6 },
                { 25, 5 }
            };

            decimal amountPaid = 4.00M, costOfPurchase = 2.35M;

            Dictionary<int, int> results = CalculateChange(amountPaid, costOfPurchase, denominations);

            Console.WriteLine("Coins Returned: ");

            foreach (var result in results)
            {
                var countOfCoins = result.Key;
                var coinValue = result.Value;

                Console.WriteLine("{0} -- {1} cents coins", countOfCoins, coinValue);
            }

            Console.Read();
        }

        static Dictionary<int, int> CalculateChange(decimal amountPaid, decimal costOfPurchase, Dictionary<int, int> denominations)
        {
            var change = (amountPaid - costOfPurchase) * 100;
            var resultDictionary = new Dictionary<int, int>();

            foreach (var denomination in denominations.OrderByDescending(value => value.Key))
            {
                //Singular value
                var coin = denomination.Key;
                var coinAmount = denomination.Value;
                int count = 0;

                if (change != 0)
                {
                    for (int i = 0; i < coinAmount; i++)
                    {
                        if (coin <= change)
                        {
                            change -= coin;
                            count++;
                        }
                    }

                    resultDictionary.Add(count, coin);
                }
                else
                {
                    break;
                }
            }

            return resultDictionary;
        }
    }
}
