using PatientApplication.Domain.Services;
using PatientApplication.WPF.State;
using PatientApplication.WPF.State.Authenticator;
using PatientApplication.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientApplication.WPF.Commands
{
    public class SaveCommand : AsyncCommandBase
    {
        private readonly PatientDetailsViewModel _deatilsVM;
        private readonly IRenavigator _renavigator;
        private readonly IAuthenticator _authenticator;

        public SaveCommand(PatientDetailsViewModel deatilsVM, IRenavigator renavigator, IAuthenticator authenticator)
        {
            _deatilsVM = deatilsVM;
            _renavigator = renavigator;
            _authenticator = authenticator;
            _deatilsVM.PropertyChanged += DeatilsView_Changed;
        }

        private void DeatilsView_Changed(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PatientDetailsViewModel.CanSave))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _deatilsVM.CanSave && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _deatilsVM.Errormessage = string.Empty;

            if(_authenticator == null)
            {
                throw new InvalidOperationException();
            }
            if(_deatilsVM == null){
                throw new InvalidOperationException();
            }

            try
            {
                AddtoDBResult result = await _authenticator.CreatePatient(
                    _deatilsVM.patientName,
                    _deatilsVM.patientAge,
                    _deatilsVM.PatientWeight,
                    _deatilsVM.StudyDescription,
                    _deatilsVM.Date,
                    _deatilsVM.Gender,
                    _deatilsVM.PerPhysician,
                    _deatilsVM.RefPhysician
                    );

                switch (result)
                {
                    case AddtoDBResult.Success:
                        _renavigator.Renavigate();
                        break;
                    case AddtoDBResult.IDExist:
                        _deatilsVM.Errormessage = " Patient Id is already existed.";
                        break;
                    case AddtoDBResult.IDNull:
                        _deatilsVM.Errormessage = "Patient should not be null value.";
                        break;
                    case AddtoDBResult.NameNULL:
                        _deatilsVM.Errormessage = " Patient name should not be null.";
                        break;
                    case AddtoDBResult.StudyEmpty:
                        _deatilsVM.Errormessage = " Study description should not be null";
                        break;
                    default:
                        _deatilsVM.Errormessage = "Saving to db failed.";
                        break;
                }
                
            }
            catch (Exception)
            {
                _deatilsVM.Errormessage = "Saving to db failed.";
            }
        }
    }
}
