using PatientApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Domain.Services
{
    public interface IAccountService : IDataService<UserAccounts>
    {
        Task<UserAccounts> GetByUserName(string username);
    }
}
