using PatientApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.State.Account
{
    public interface IAccountStore
    {
        UserAccounts CurrentUser { get; set; }
        event Action ViewChanged;
    }
}
