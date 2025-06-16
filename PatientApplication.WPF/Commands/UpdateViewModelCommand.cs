using PatientApplication.WPF.State;
using PatientApplication.WPF.ViewModels;
using PatientApplication.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientApplication.WPF.Commands
{
    public class UpdateViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;
        private readonly IVMsFactory _vmsFactory;

        public UpdateViewModelCommand(INavigator navigator, IVMsFactory vmFactory)
        {
            _navigator = navigator;
            _vmsFactory = vmFactory;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                
                _navigator.CurrentViewModel = _vmsFactory.CreateViewModel(viewType);
            }
        }
    }
}
