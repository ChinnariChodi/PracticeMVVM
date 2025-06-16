using PatientApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientApplication.Entity;
using Microsoft.EntityFrameworkCore;
using PatientApplication.Entity.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PatientApplication.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly PatientDbContextFactory _contextFactory;

        public AccountService(PatientDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<UserAccounts> Create(UserAccounts entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccounts> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccounts> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserAccounts>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccounts> GetByUserName(string username)
        {
            using (PatientDbContext context = _contextFactory.CreateDbContext())
            {
                //var user = await context.Accounts.Include(a => a.UserName)
                //    .FirstOrDefaultAsync(a => a.UserName == username);

                //return user;


                var user = await context.UserAccounts
                            .FirstOrDefaultAsync(a => a.UserName == username);  // No need for Include

                return user;
            }

            
        }

        public async Task<UserAccounts> Update(int id, UserAccounts entity)
        {
            throw new NotImplementedException();
        }
    }
}
