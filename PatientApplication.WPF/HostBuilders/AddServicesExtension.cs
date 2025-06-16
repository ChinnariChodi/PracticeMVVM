using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientApplication.Domain.Models;
using PatientApplication.Domain.Services;
using PatientApplication.Entity.Services;
using PatientApplication.WPF.State;
using PatientApplication.WPF.ViewModels;

namespace PatientApplication.WPF.HostBuilders
{
    public static class AddServicesExtension
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(service =>
            {
                service.AddSingleton<IPasswordHasher, PasswordHasher>();
                service.AddSingleton<IDataService<Patients>, GenericDataServices<Patients>>();
                service.AddSingleton<IAccountService, AccountService>();
                service.AddSingleton<IAuthenticationService, AuthenticationService>();
                service.AddSingleton<IRenavigator, Renavigator<LoginViewModel>>();
            });

            return host;
        }
    }
}
