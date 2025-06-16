using PatientApplication.WPF.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.ViewModels.Factories
{
    public interface IVMsFactory
    {
        BaseViewModel CreateViewModel(ViewType viewType);
    }
}
