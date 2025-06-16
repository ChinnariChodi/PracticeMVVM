using PatientApplication.Domain.Models;
using PatientApplication.Domain.Services;
using PatientApplication.WPF.Commands;
using PatientApplication.WPF.State;
using PatientApplication.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientApplication.WPF.ViewModels
{
    public class PatientListViewModel :BaseViewModel
    {
        private readonly INavigator _navigation;
        private readonly IVMsFactory _vmFactory;
        private readonly IRenavigator _renavigator;
        private readonly IDataService<Patients> _dataservice;
        private readonly ObservableCollection<Patients> _records;
        private readonly PatientDetailsViewModel _detailsViewModel;

        private readonly List<Patients> _precords;

        public ObservableCollection<Patients> PatientList => _records;
        public IEnumerable<Patients> Records => _precords;
        public ICommand CreateCommand { get; set; }
        public ICommand LoadRecordsCommand { get; set; }
        public ICommand LoadDetailsCommand { get; set; }

        private Patients _selectedrecord;
        public Patients SelectedRecord
        {
            get { return _selectedrecord; }
            set {
                if (_selectedrecord != value)
                {
                    _selectedrecord = value;
                    OnPropertyChanged(nameof(SelectedRecord));
                }
            }
        }

        public PatientListViewModel(INavigator navigation, IVMsFactory vmFactory,IRenavigator renavigator,
            IDataService<Patients> dataservice)
        {
            _navigation = navigation;
            _vmFactory = vmFactory;
            _dataservice = dataservice;
            _renavigator = renavigator;
            _records = new ObservableCollection<Patients>();
            _precords = new List<Patients>();

            CreateCommand = new CreateCommand(_navigation, _vmFactory);
            LoadRecordsCommand = new LoadRecordsCommand(this);
            LoadDetailsCommand = new LoadDetailsCommand(this,_navigation,_vmFactory,_dataservice);
        }

        public async Task LoadRecords()
        {
            IEnumerable<Patients> records = await _dataservice.GetAll();
            _precords.Clear();
            _precords.AddRange(records);
        }
        public void UpdateRecords(IEnumerable<Patients> records)
        {
            _records.Clear();

            foreach (var record in records)
            {
                _records.Add(record);
            }
        }
    }
}
