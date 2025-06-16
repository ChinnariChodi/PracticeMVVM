using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Domain.Exceptions
{
    public class InvalidPassWordException : Exception
    {
        public string Username { get; set; }
        public string PassWord { get; set; }

        public InvalidPassWordException(string username, string password)
        {
            Username = username;
            PassWord = password;
        }

        public InvalidPassWordException(string message, string username, string password) : base(message)
        {
            Username = username;
            PassWord = password;
        }

        public InvalidPassWordException(string message, Exception innerException, string username, string password) : base(message, innerException)
        {
            Username = username;
            PassWord = password;
        }

    }
}
