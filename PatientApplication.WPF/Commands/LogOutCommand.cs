using PatientApplication.WPF.State;
using PatientApplication.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientApplication.WPF.Commands
{
    public class LogOutCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigation;
        private readonly IVMsFactory _vmFactory;

        public LogOutCommand(INavigator navigation, IVMsFactory vmFactory)
        {
            _navigation = navigation;
            _vmFactory = vmFactory;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
           if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigation.CurrentViewModel = _vmFactory.CreateViewModel(viewType);
            }
        }
    }
}
