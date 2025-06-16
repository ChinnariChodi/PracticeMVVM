using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Domain.Exceptions
{
    public class InvalidUserException : Exception
    {
      
        public string UserName { get; set; }

        public InvalidUserException(string userName)
        {
            UserName = userName;
        }

        public InvalidUserException(string message, string userName) : base(message) 
        {
            UserName = userName;
        }

        public InvalidUserException(string message,Exception innerException, string userName) : base(message,innerException)
        {
            UserName = userName;
        }

    }
}
