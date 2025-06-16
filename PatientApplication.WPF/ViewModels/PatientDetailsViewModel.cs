using PatientApplication.Domain.Models;
using PatientApplication.Domain.Services;
using PatientApplication.WPF.Commands;
using PatientApplication.WPF.State;
using PatientApplication.WPF.State.Authenticator;
using PatientApplication.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientApplication.WPF.ViewModels
{
    public class PatientDetailsViewModel : BaseViewModel
    {
        public PatientDetailsViewModel(INavigator navigator, IVMsFactory vmfactory,
            IRenavigator renavigator, IAuthenticator authenticator)
        {
            ErrorMessages = new MessageViewModel();

            CancelCommand = new CancelCommand(navigator, vmfactory);
            CancelCommand.Execute(ViewType.PatientListView);

            SaveCommand = new SaveCommand(this, renavigator, authenticator);
        }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public bool CanSave =>
            !string.IsNullOrEmpty(patientName) &&
            !string.IsNullOrEmpty(StudyDescription);

        public MessageViewModel ErrorMessages { get; }

        public string Errormessage
        {
            set => ErrorMessages.Message = value;
        }

        private bool _isSaveButtonVisible = true;
        public bool IsSaveButtonVisible
        {
            get => _isSaveButtonVisible;
            set
            {
                _isSaveButtonVisible = value;
                OnPropertyChanged(nameof(IsSaveButtonVisible));
            }
        }

        private int _id;
		public int PatientID
		{
			get { return _id; }
			set 
			{
                    _id = value;
                    OnPropertyChanged(nameof(PatientID));
                OnPropertyChanged(nameof(CanSave));
            }
		}

		private string _patientname;
		public string patientName
		{
			get { return _patientname; }
			set
			{
					_patientname = value;
					OnPropertyChanged(nameof(patientName));
                OnPropertyChanged(nameof(CanSave));
            }
		}

        private int _patientage;
        public int patientAge
        {
            get { return _patientage; }
            set
            {
                    _patientage = value;
                    OnPropertyChanged(nameof(patientAge));
            }
        }

		private int _patientweight;
		public int PatientWeight
		{
			get { return _patientweight; }
			set {
                    _patientweight = value;
                    OnPropertyChanged(nameof(PatientWeight));
            }
		}

		private string _studydescription;
		public string StudyDescription
		{
			get { return _studydescription; }
			set { 
                    _studydescription = value;
                    OnPropertyChanged(nameof(StudyDescription));
                OnPropertyChanged(nameof(CanSave));
            }
        }

		private DateTime _date = DateTime.Now;
		public DateTime Date
		{
			get { return _date; }
			set
			{
				_date = value;
				OnPropertyChanged(nameof(Date));
			}
		}

		private string _gender;
		public string Gender
		{
			get { return _gender; }
			set 
			{ 
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
            }
		}

        private string _perphy;
        public string PerPhysician
        {
            get { return _perphy; }
            set
            {
                _perphy = value;
                OnPropertyChanged(nameof(PerPhysician));
            }
        }

        private string _refphy;
        public string RefPhysician
        {
            get { return _refphy; }
            set
            {
                _refphy = value;
                OnPropertyChanged(nameof(RefPhysician));
            }
        }

        public void DisplaySelectedPatientDetails(Patients record)
        {
            // For example, set the fields directly in the PatientListViewModel or another relevant ViewModel
            // You can add properties to display the details in the view
            this.PatientID = record.Id;
            this.patientName = record.Name;
            this.Date = record.Date;
            this.patientAge = record.Age;
            this.PatientWeight = record.Weight;
            this.Gender = record.Gender;
            this.PerPhysician = record.PerPhysician;
            this.RefPhysician = record.RefPhysician;

            // If you have a view or control that displays this data, update it here
            // Alternatively, trigger some event to refresh the view with these details
        }

        public override void Dispose()
        {
            ErrorMessages.Dispose();

            base.Dispose();
        }
    }
}
