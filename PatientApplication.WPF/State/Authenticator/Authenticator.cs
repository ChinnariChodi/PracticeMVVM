using PatientApplication.Domain.Models;
using PatientApplication.Domain.Services;
using PatientApplication.WPF.State.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.State.Authenticator
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService,
            IAccountStore accountService)
        {
            _authenticationService = authenticationService;
            _accountStore = accountService;
        }

        public UserAccounts CurrentLogin
        {
            get
            {
                return _accountStore.CurrentUser;
            }
            set
            {
                _accountStore.CurrentUser = value;
                ViewChanged?.Invoke();
            }
        }
        public bool IsLoggedIn => CurrentLogin != null;
        public bool IsLoggedOut => CurrentLogin != null;

        public event Action ViewChanged;

        public async Task<AddtoDBResult> CreatePatient(string name, int age, int weight, string study, DateTime date,string gender, string perphy, string refphy)
        {
            return await _authenticationService.CreatePatient(name, age, weight, study, date, gender, perphy, refphy);
        }

        public async Task Login(string username, string password)
        {
            CurrentLogin = await _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            CurrentLogin = null;
            ViewChanged?.Invoke();
        }

    }
}
