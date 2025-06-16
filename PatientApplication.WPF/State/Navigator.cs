using PatientApplication.WPF.Commands;
using PatientApplication.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientApplication.WPF.State
{
    public class Navigator : INavigator
    {

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                ViewChanged?.Invoke();
            }
        }

        public event Action ViewChanged;
    }
}
