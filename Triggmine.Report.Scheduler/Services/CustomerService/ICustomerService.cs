using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triggmine.Report.Scheduler.Models;

namespace Triggmine.Report.Scheduler.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetcustomersByRegistrationDate(DateTime startDate, DateTime endDate);

    }
}
