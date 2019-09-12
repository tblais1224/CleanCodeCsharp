using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{

    public class GetCustomersResults
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int totalCount { get; set; }
    }
    class OutputParams
    {
        public void DisplayCustomers()
        {
            const int pageIndex = 1;
            var results = GetCustomers(pageIndex);

            Console.WriteLine("total customers: " + results.totalCount);
            foreach (var c in results.Customers)
            {
                Console.WriteLine(c);
            }

        }

        public GetCustomersResults GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomersResults() { Customers = new List<Customer>(), totalCount = totalCount };
        }
    }
}
