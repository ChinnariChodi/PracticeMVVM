using PatientApplication.Domain.Models;
using PatientApplication.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.Commands
{
    public class LoadRecordsCommand : AsyncCommandBase
    {
        private readonly PatientListViewModel _listViewModel;
        private readonly List<Patients> _records;
        public IEnumerable<Patients> Records => _records;

        public LoadRecordsCommand(PatientListViewModel listViewModel)
        {
            _listViewModel = listViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _listViewModel.LoadRecords();

                _listViewModel.UpdateRecords(_listViewModel.Records);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
