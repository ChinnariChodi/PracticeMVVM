using Microsoft.AspNet.Identity;
using PatientApplication.Domain.Exceptions;
using PatientApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IDataService<Patients> _dataservice;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher, IDataService<Patients> dataservice)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
            _dataservice = dataservice;
        }

        public async Task<UserAccounts> Login(string username, string password)
        {
            UserAccounts accounts = await _accountService.GetByUserName(username);

            if (accounts == null)
            {
                throw new InvalidUserException(username);
            }

            //PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(accounts.Password, password);
            string hashedPassword = _passwordHasher.HashPassword(password);
            var verificationResult = _passwordHasher.VerifyHashedPassword(hashedPassword, password);
            //var verificationResult1 = _passwordHasher.VerifyHashedPassword(accounts.Password, hashedPassword);

            if (verificationResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPassWordException(username, password);
            }

            return accounts;
        }

        public void LogOut()
        {
            if(_accountService != null)
            {
                return;
            }
        }

        public async Task<AddtoDBResult> CreatePatient(string name, int age, int weight, string study, DateTime date, string gender,string perphy, string refphy)
        {
            AddtoDBResult result = AddtoDBResult.Success;
            
            //Patients patientid = await _dataservice.Get(id);
            //if(patientid != null)
            //{
            //    result = AddtoDBResult.IDExist;
            //}

            if(name == null)
            {
                result = AddtoDBResult.NameNULL;
            }
            if(study == null)
            {
                result = AddtoDBResult.StudyEmpty;
            }

            if(result == AddtoDBResult.Success)
            {
                Patients patient = new Patients()
                {
                    Name = name,
                    Age = age,
                    Weight = weight,
                    StudyDescription = study,
                    Date = date,
                    Gender = gender,
                    PerPhysician = perphy,
                    RefPhysician = refphy
                };

                await _dataservice.Create(patient);
            }

            return result;
        }
    }
}
