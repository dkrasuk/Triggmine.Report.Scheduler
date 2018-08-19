using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triggmine.Report.Scheduler.Data.Context
{
    public class ReportSchedulerBootstrapper
    {

        private ReportSchedulerBootstrapper() { }
        public static ReportSchedulerBootstrapper Instance { get; } = new ReportSchedulerBootstrapper();
        public IConfiguration Configuration { get; set; }

        public string ConnectionString(string connectionStringName) => Configuration[$"ConnectionStrings:{connectionStringName}"];
        public string Schema(string schemaName) => Configuration[$"ConnectionStrings:{schemaName}"];

    }
}
