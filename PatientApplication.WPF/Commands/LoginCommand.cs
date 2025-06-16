using PatientApplication.Domain.Exceptions;
using PatientApplication.WPF.State;
using PatientApplication.WPF.State.Authenticator;
using PatientApplication.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, 
            IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        private void LoginViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _loginViewModel.CanLogin && base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                await _authenticator.Login(_loginViewModel.UserName, _loginViewModel.RealText);

                _renavigator.Renavigate();
            }
            catch (InvalidUserException)
            {
                _loginViewModel.ErrorMessage = "Enter correct Username";
            }
            catch (InvalidPassWordException)
            {
                _loginViewModel.ErrorMessage = "Incorrect Password.";
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Login Failed.";
            }
        }
    }
}
