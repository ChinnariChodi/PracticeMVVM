using PatientApplication.WPF.Commands;
using PatientApplication.WPF.State;
using PatientApplication.WPF.State.Authenticator;
using PatientApplication.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientApplication.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private  readonly IVMsFactory _vmFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public bool IsLoggedOut => _authenticator.IsLoggedOut;

        public ICommand UpdateViewModelCommand { get; }
        public ICommand LogoutCommand { get; }

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;
        public MainViewModel(IVMsFactory vmFactory, 
            INavigator navigator, IAuthenticator authenticator)
        {
            _vmFactory = vmFactory;
            _navigator = navigator;
            _authenticator = authenticator;

            _navigator.ViewChanged += Navigator_ViewChnaged;
            _authenticator.ViewChanged += Authenticator_ViewChanged;

            UpdateViewModelCommand = new UpdateViewModelCommand(navigator, _vmFactory);
            UpdateViewModelCommand.Execute(ViewType.LoginView);

            //LogoutCommand = new LogOutCommand(navigator, _vmFactory);
            //LogoutCommand.Execute(ViewType.LoginView);
        }

        private void Authenticator_ViewChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_ViewChnaged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            _navigator.ViewChanged -= Navigator_ViewChnaged;
            _authenticator.ViewChanged -= Authenticator_ViewChanged;

            base.Dispose();
        }
    }
}
