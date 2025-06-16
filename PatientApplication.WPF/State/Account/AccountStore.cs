using PatientApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.State.Account
{
    public class AccountStore : IAccountStore
    {
        private UserAccounts _currentuser;

        public UserAccounts CurrentUser
        {
            get { return _currentuser; }
            set
            {
                _currentuser = value;
                ViewChanged?.Invoke();
            }
        }

        public event Action ViewChanged;
    }
}
