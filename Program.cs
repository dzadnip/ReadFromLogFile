using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromLogFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "";
            Dictionary<string, int> customerOrderCount = new Dictionary<string, int>();

            System.IO.StreamReader file = new System.IO.StreamReader("orders.csv");
            while ((line = file.ReadLine()) != null)
            {
                if(line != ""){
                    string[] orderDetails = line.Split(',').ToArray();
                    if(customerOrderCount.ContainsKey(orderDetails[1]))
                    {
                        customerOrderCount[orderDetails[1]] = customerOrderCount[orderDetails[1]] + 1;
                    } else
                    {
                        customerOrderCount.Add(orderDetails[1], 1);
                    }
                }
                
            }

            file.Close();

            int mostOrders = 0;
            string customerWithMostOrders = "";

            foreach (var customer in customerOrderCount)
            {
                if (customer.Value > mostOrders)
                {
                    mostOrders = customer.Value;
                    customerWithMostOrders = customer.Key;
                }
            }

            Console.WriteLine(customerWithMostOrders + " had the most orders " + mostOrders);

            Console.ReadLine();

        }
    }
}
