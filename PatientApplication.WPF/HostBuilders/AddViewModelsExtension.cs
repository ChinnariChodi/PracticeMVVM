using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientApplication.Domain.Models;
using PatientApplication.Domain.Services;
using PatientApplication.WPF.State;
using PatientApplication.WPF.State.Authenticator;
using PatientApplication.WPF.ViewModels;
using PatientApplication.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.HostBuilders
{
    public static class AddViewModelsExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient(CreatePatientViewModel);
                services.AddTransient<PatientListViewModel>();
                services.AddTransient<StatusViewModel>();
                services.AddTransient<ModesViewModel>();
                services.AddTransient<LayOutViewModel>();
                services.AddTransient<PatientDetailsViewModel>();
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<PatientListViewModel>>(services => () => CreatePatientViewModel(services));
                services.AddSingleton<CreateViewModel<PatientDetailsViewModel>>(services => () => CreateDetailsViewModel(services));
                services.AddSingleton<CreateViewModel<StatusViewModel>>(services => () => services.GetRequiredService<StatusViewModel>());
                services.AddSingleton<CreateViewModel<ModesViewModel>>(services => () => services.GetRequiredService<ModesViewModel>());
                services.AddSingleton<CreateViewModel<LayOutViewModel>>(services => () => services.GetRequiredService<LayOutViewModel>());
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));

                services.AddSingleton<IVMsFactory, VMFactory>();

                services.AddSingleton<Renavigator<PatientListViewModel>>();
                services.AddSingleton<Renavigator<LoginViewModel>>();
            });

            return host;
        }     


        private static PatientListViewModel CreatePatientViewModel(IServiceProvider services)
        {
            var viewmodel = new PatientListViewModel(
                services.GetRequiredService<INavigator>(),
                services.GetRequiredService<IVMsFactory>(),
                services.GetRequiredService<IRenavigator>(),
                services.GetRequiredService<IDataService<Patients>>());
            
            viewmodel.LoadRecordsCommand.Execute(null); ;

            return viewmodel;
        }

        private static PatientDetailsViewModel CreateDetailsViewModel(IServiceProvider services)
        {
            return new PatientDetailsViewModel(
                services.GetRequiredService<INavigator>(),
                services.GetRequiredService<IVMsFactory>(),
                services.GetRequiredService<Renavigator<PatientListViewModel>>(),
                services.GetRequiredService<IAuthenticator>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<Renavigator<PatientListViewModel>>());
        }
    }
}
