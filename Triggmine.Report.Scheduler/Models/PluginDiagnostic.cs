using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triggmine.Report.Scheduler.Models
{
    public class PluginDiagnostic
    {
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public string DiagnosticType { get; set; }
        public int Status { get; set; }
        public string CabinetName { get; set; }
    }
}
