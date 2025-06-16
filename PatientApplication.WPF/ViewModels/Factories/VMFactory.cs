using PatientApplication.WPF.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.ViewModels.Factories
{
    public class VMFactory : IVMsFactory
    {
        private readonly CreateViewModel<PatientListViewModel> _createPatientListVM;
        private readonly CreateViewModel<StatusViewModel> _createStausVM;
        private readonly CreateViewModel<ModesViewModel> _createModestVM;
        private readonly CreateViewModel<LayOutViewModel> _createLayoutVM;
        private readonly CreateViewModel<PatientDetailsViewModel> _createPatientDetailsVM;
        private readonly CreateViewModel<LoginViewModel> _createLoginVM;

        public VMFactory(CreateViewModel<PatientListViewModel> createPatientListVM,
            CreateViewModel<PatientDetailsViewModel> createPatientDetailsVM,
            CreateViewModel<StatusViewModel> createStausVM,
            CreateViewModel<ModesViewModel> createModestVM,
            CreateViewModel<LayOutViewModel> createLayoutVM,
            CreateViewModel<LoginViewModel> createLoginVM)
        {
            _createPatientListVM = createPatientListVM;
            _createPatientDetailsVM = createPatientDetailsVM;
            _createStausVM = createStausVM;
            _createModestVM = createModestVM;
            _createLayoutVM = createLayoutVM;
            _createLoginVM = createLoginVM;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.PatientListView:
                    return _createPatientListVM();
                case ViewType.StatusView:
                    return _createStausVM();
                case ViewType.ModesView:
                    return _createModestVM();
                case ViewType.LayoutView:
                    return _createLayoutVM();
                case ViewType.PatientDetailListView:
                    return _createPatientDetailsVM();
                case ViewType.LoginView:
                    return _createLoginVM();

                default:
                    throw new ArgumentException("the viewtype does not have viewmodel");
            }
        }
    }
}
