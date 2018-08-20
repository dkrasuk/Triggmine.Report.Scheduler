using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triggmine.Report.Scheduler.Data.Context;
using Triggmine.Report.Scheduler.Models;

namespace Triggmine.Report.Scheduler.Services.CabinetService
{
    public class CabinetService : ICabinetService
    {
        private readonly string ConnectionString;
        public CabinetService()
        {
            ConnectionString = ReportSchedulerBootstrapper.Instance.ConnectionString("CabinetConnection");
        }

        private async Task<NpgsqlConnection> GetConnection(string connectionString)
        {
            try
            {
                return new NpgsqlConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<string>> GetAllSchemas()
        {
            List<string> listCabinets = new List<string>();
            var connection = await GetConnection(ConnectionString);

            if (connection == null)
                return null;

            try
            {
                connection.Open();
                string sql = $"select schemaname from pg_tables where schemaname not like '%bak' and tablename = 'react_plugin_diagnostic'";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            listCabinets.Add(reader.GetString(0));
                        }
                        return listCabinets;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<PluginDiagnostic>> GetPluginDiagnostic(List<string> cabinetList)
        {
            List<PluginDiagnostic> listPluginDiagnostic = new List<PluginDiagnostic>();
            var connection = await GetConnection(ConnectionString);

            if (connection == null)
                return null;

            try
            {
                connection.Open();


                foreach (var schema in cabinetList)
                {
                    string sql = $"select date_created, description, diagnostic_type, status from {schema}.react_plugin_diagnostic where status = 1 ORDER BY date_created desc limit 1";

                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                listPluginDiagnostic.Add(new PluginDiagnostic()
                                {
                                    DateCreated = reader.GetDateTime(0),
                                    Description = reader.GetString(1),
                                    DiagnosticType = reader.GetString(2),
                                    Status = reader.GetInt16(3),
                                    CabinetName = schema
                                });
                            }
                        }
                    }
                }
                return listPluginDiagnostic;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
