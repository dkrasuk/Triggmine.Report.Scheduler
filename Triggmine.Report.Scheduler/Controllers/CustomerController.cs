using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Triggmine.Report.Scheduler.Models;
using Triggmine.Report.Scheduler.Services.CabinetService;
using Triggmine.Report.Scheduler.Services.CustomerService;

namespace Triggmine.Report.Scheduler.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICabinetService _cabinetServise;
        public CustomerController(ICustomerService customerService, ICabinetService cabinetServise)
        {
            _customerService = customerService;
            _cabinetServise = cabinetServise;
        }
        public async Task<IActionResult> GetCustomersAsync()
        {
            List<Customer> customer = await _customerService.GetAllCustomers();
           // var cabinets = await _cabinetServise.GetAllSchemas();
          //  var plugins = await _cabinetServise.GetPluginDiagnostic(cabinets);

            return View("Customers", customer);            
        }
         
    }
}