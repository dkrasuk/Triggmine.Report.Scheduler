using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triggmine.Report.Scheduler.Models;

namespace Triggmine.Report.Scheduler.Services.CabinetService
{
    public interface ICabinetService
    {
        Task<List<string>> GetAllSchemas();
        Task<List<PluginDiagnostic>> GetPluginDiagnostic(List<string> cabinetList);
    }
}
