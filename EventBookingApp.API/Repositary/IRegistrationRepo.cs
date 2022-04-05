using DataAcessLayer;
using DataAcessLayer.ViewModel;
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
        //Task<ApplicationUser> GetUserByEmail(string email);
       // public int SignInMethod(string email, string password);
        public ApplicationUser SignInMethod(string email, string password);
        Task<ApplicationUser> ChangePassword(ChangePasswordModel chagePassword);

    }
}
