using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace CleanCode.Comments
{
    class Comments
    {
        private int _payFrequency;
        private CustomersDbConext _dbContext;

        public Comments()
        {
            _dbContext = new CustomersDbConext();
        }

        public List<Customer> GetCustomers(int countryCode)
        {
            //TODO: we need to get rid of abcd once we revisit this method currently
            // its creating a couple between x and y because of that were not able to do
            // xyz   (this is a good comment to keep until problem is fixed)

            throw new NotImplementedException();
        }

        public void SubmitOrder(Order order)
        {
            SaveOrder(order);

            NotifyCustomer(order);
        }

        private void SaveOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        private static void NotifyCustomer(Order order)
        {
            var client = new SmtpClient();
            var mail = new MailMessage("noreply@site.com", order.Customer.Email, "Your order placed successfully", ".");
            client.Send(mail);
        }
    }
}
