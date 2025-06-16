using PatientApplication.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.State
{
    //public class Renavigator<TViewModel> : IRenavigator where TViewModel : BaseViewModel
    //{
    //    private readonly INavigator _navigator;
    //    private readonly CreateViewModel<TViewModel> _createViewModel;

    //    public Renavigator(INavigator navigator, CreateViewModel<TViewModel> createViewModel)
    //    {
    //        _navigator = navigator;
    //        _createViewModel = createViewModel;
    //    }

    //    public void Renavigate()
    //    {
    //        _navigator.CurrentViewModel = _createViewModel();
    //    }
    //}

    public class Renavigator<TViewModel> : IRenavigator where TViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public Renavigator(INavigator navigator, CreateViewModel<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
