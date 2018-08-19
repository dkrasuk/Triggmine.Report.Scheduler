using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triggmine.Report.Scheduler.Data.Context;
using Triggmine.Report.Scheduler.Models;

namespace Triggmine.Report.Scheduler.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        public async Task<List<Customer>> GetAllCustomers()
        {
            using (var context = new AuthorizationContext())
            {
                return context.Customer.ToList();
            }
        }
        public async Task<List<Customer>> GetcustomersByRegistrationDate(DateTime startDate, DateTime endDate)
        {
            using (var context = new AuthorizationContext())
            {
                return context.Customer.Where(n => n.RegistrationDate > startDate && n.RegistrationDate < endDate).ToList();
            }
        }
    }
}
