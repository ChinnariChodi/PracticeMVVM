using PatientApplication.Domain.Models;
using PatientApplication.Domain.Services;
using PatientApplication.WPF.State;
using PatientApplication.WPF.ViewModels;
using PatientApplication.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PatientApplication.WPF.Commands
{
    public class LoadDetailsCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        private readonly IVMsFactory _vmsFactory;
        private readonly IDataService<Patients> _dataService;
        private readonly PatientListViewModel _patientListViewModel;

        public LoadDetailsCommand(PatientListViewModel view,
            INavigator navigator, IVMsFactory vmsFactory, IDataService<Patients> dataservice)
        {
            _patientListViewModel = view;
            _navigator = navigator;
            _vmsFactory = vmsFactory;
            _dataService = dataservice;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                    var detailsViewModel = _vmsFactory.CreateViewModel(ViewType.PatientDetailListView) as PatientDetailsViewModel;

                    if (detailsViewModel != null)
                    {
                    detailsViewModel.IsSaveButtonVisible = false;
                    // Load patient details using the selected patient from the command parameter
                    var patientDetails = await _dataService.Get(_patientListViewModel.SelectedRecord.Id);

                        if (patientDetails != null)
                        {
                            // Update the PatientDetailsViewModel with loaded details
                            detailsViewModel.PatientID = patientDetails.Id;
                            detailsViewModel.patientName = patientDetails.Name;
                            detailsViewModel.Date = patientDetails.Date;
                            detailsViewModel.patientAge = patientDetails.Age;
                            detailsViewModel.PatientWeight = patientDetails.Weight;
                            detailsViewModel.Gender = patientDetails.Gender;
                            detailsViewModel.StudyDescription = patientDetails.StudyDescription;
                            detailsViewModel.PerPhysician = patientDetails.PerPhysician;
                            detailsViewModel.RefPhysician = patientDetails.RefPhysician;

                            // Set the updated details view model as the current view
                            _navigator.CurrentViewModel = detailsViewModel;
                        }
                        else
                        {
                            MessageBox.Show("Patient details not found.");
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading details: {ex.Message}");
            }
        }

    }
}
