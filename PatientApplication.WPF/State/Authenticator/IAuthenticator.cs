using PatientApplication.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.WPF.State.Authenticator
{
    public interface IAuthenticator
    {
        bool IsLoggedIn { get; }
        bool IsLoggedOut {  get; }

        event Action ViewChanged;


        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task Login(string username, string password);

        void Logout();

        Task<AddtoDBResult> CreatePatient( string name, int age, int weight, string study, 
    DateTime date, string gender,string perphy, string refphy);

    }
}
