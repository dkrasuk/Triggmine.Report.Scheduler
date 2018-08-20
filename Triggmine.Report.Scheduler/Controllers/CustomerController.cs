using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Triggmine.Report.Scheduler.Models;
using Triggmine.Report.Scheduler.Services.CustomerService;

namespace Triggmine.Report.Scheduler.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<IActionResult> GetCustomersAsync()
        {

            List<Customer> customer = await _customerService.GetAllCustomers();

            return View("Customers", customer);            
        }
    }
}