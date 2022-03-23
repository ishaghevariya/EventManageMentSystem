using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public interface IRegistrationRepo
    {
        Task<ApplicationUser> UserRegistration(ApplicationUser applicationUser);
        Task<ApplicationUser> GetUser(int id);
        public int SignInMethod(string email, string password);

    }
}
