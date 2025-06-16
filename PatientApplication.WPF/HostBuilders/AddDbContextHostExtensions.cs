using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.HostBuilders
{
    public static class AddDbContextHostExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((connection, services) =>
            {
                string connectionstring = connection.Configuration.GetConnectionString("sqlserver");

                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(connectionstring);

                services.AddDbContext<PatientDbContext>(configureDbContext);
                //services.AddSingleton<PatientDbContextFactory>(new PatientDbContextFactory(configureDbContext));

                services.AddTransient<PatientDbContextFactory>(_ => new PatientDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
