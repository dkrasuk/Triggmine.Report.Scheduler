using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Triggmine.Report.Scheduler.Data.Context;

namespace Triggmine.Report.Scheduler.Data.Context
{
    public partial class TmContext : DbContext
    {
        public TmContext()
        {
        }

        public TmContext(DbContextOptions<TmContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ReportSchedulerBootstrapper.Instance.ConnectionString("CabinetConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
        }
    }
}
