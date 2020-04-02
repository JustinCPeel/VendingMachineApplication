using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace VendingMachine_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var coinDenominationsUS = new[] { 1, 5, 10, 25 };
            var coinDenominationsUK = new[] { 1, 2, 5, 10, 20, 50 };
            
            decimal tenderAmount = 2.00M, purchasePrice = 1.35M;

            var result = CalculateChange(tenderAmount, purchasePrice, coinDenominationsUS.OrderByDescending(value => value).ToArray());

            Console.WriteLine($"Coins Returned: {string.Join(",", result)}");
            Console.Read();
        }

        static string[] CalculateChange(decimal tenderAmount, decimal purchasePrice, int[] denominations)
        {
            var amountOwed = (tenderAmount - purchasePrice) * 100;
            var result = new List<string>();

            foreach (var denomination in denominations)
            {
                if (amountOwed != 0)
                {
                    amountOwed -= denomination;
                    result.Add(denomination.ToString());
                }
                else
                {
                    break;
                }
            }

            return result.ToArray();
        }
    }
}
