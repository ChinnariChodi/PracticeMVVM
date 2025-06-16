using PatientApplication.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientApplication.WPF.State
{
    public enum ViewType
    {
        LoginView,
        PatientListView,
        PatientDetailListView,
        StatusView,
        ModesView,
        LayoutView,
    }
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        event Action ViewChanged;
    }
}
