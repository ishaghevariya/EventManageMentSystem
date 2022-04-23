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
        Task<ApplicationUser> GetUserByEmail(string email);
        // public int SignInMethod(string email, string password);
        public int SignInMethod(string email, string password);
        Task<ApplicationUser> ChangePassword(ChangePasswordModel chagePassword);
        Task<ApplicationUser> ForgotPassword(ForgotPasswordViewModel forgetPassword);
        Task<ApplicationUser> ResetPassword(ResetPasswordViewModel viewModel);
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<IEnumerable<ApplicationUser>> GetUsersByPaggination(int pageNo,int pageSize);
        Task<ApplicationUser> DeleteUser(int id);
        Task<IEnumerable<ApplicationUser>> Search(string name);
        Task<ApplicationUser> Profile(ApplicationUser User);
        Task<FeedBack> FeedBack(FeedbackViewModel feedBack);
        Task<FeedBack> GetFeedBack(int id);
        Task<IEnumerable<FeedBack>> GetAllFeedBack();
        Task<FeedBack> DeleteFeedback(int id);

    }
}
