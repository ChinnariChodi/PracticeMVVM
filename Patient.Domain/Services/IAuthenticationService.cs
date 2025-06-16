using PatientApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Domain.Services
{

    public enum AddtoDBResult
    {
        Success,
        IDNull,
        NameNULL,
        IDExist,
        StudyEmpty
    }
    public interface IAuthenticationService
    { 
      
        /// <summary>
        /// Get an account for a user's credentials.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The account for the user.</returns>
        /// <exception cref="InavlidUserException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task<UserAccounts> Login(string username, string password);

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="name">The user's email.</param>
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<AddtoDBResult> CreatePatient( string name, int age, int weight, string study,
            DateTime date, string gender, string perphy, string refphy);

        void LogOut();
    }
}
