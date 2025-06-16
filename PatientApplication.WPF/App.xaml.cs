using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientApplication.Entity;
using PatientApplication.WPF.HostBuilders;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PatientApplication.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddDbContext()
                .AddServices()
                .AddStores()
                .AddViewModels()
                .AddViews();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            PatientDbContextFactory contextFactory = _host.Services.GetRequiredService<PatientDbContextFactory>();
            //using(PatientDbContext context = contextFactory.CreateDbContext())
            //{
            //    if (context.Database.GetPendingMigrations().Any())
            //    {
            //        context.Database.Migrate(); // Apply pending migrations if needed
            //    }
            //}
            using (PatientDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.EnsureCreated(); // Only creates the database if it doesn't exist
            }

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);

        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }

}
