using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientApplication.WPF.State;
using PatientApplication.WPF.State.Account;
using PatientApplication.WPF.State.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.HostBuilders
{
    public static class AddStoresExtension
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();
            });

            return host;
        }
    }
}
