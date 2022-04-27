using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly ApplicationDbContext _context;

        public RegistrationRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationUser> GetUser(int id)
        {
            return await _context.ApplicationUsers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ApplicationUser> ChangePassword(ChangePasswordModel chagePassword)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == chagePassword.id);
            if (user != null)
            {
                if (user.Password == chagePassword.CurrentPassword)
                {
                    user.Password = chagePassword.NewPassword;
                    await _context.SaveChangesAsync();
                    return user;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        //public int SignInMethod(string email, string password)
        //{
        //    var result = _context.ApplicationUsers.Where(x => x.Email == email && x.Password == password).Count();

        //    return result;
        //}

        public int SignInMethod(string email, string password)
        {
            var user = _context.ApplicationUsers.Where(x => x.Email == email && x.Password == password).Select(x=>x.Id).SingleOrDefault();
            return user;
        }
        public async Task<ApplicationUser> UserRegistration(ApplicationUserViewModel applicationUser)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = applicationUser.UserName,
                Password = applicationUser.Password,
                Email = applicationUser.Email,
                ContactNo = applicationUser.ContactNo,
                UserRole = "User",
                Address = applicationUser.Address,
                Gender = applicationUser.Gender,
                City = applicationUser.City,
                State = applicationUser.State,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
           
                var result = await _context.ApplicationUsers.AddAsync(user);
                await _context.SaveChangesAsync();
                return result.Entity;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            //ApplicationUser user = new ApplicationUser();
            //if(user.UserRole == "User")
            //{
            var result = await _context.ApplicationUsers.ToListAsync();
            return result;
            //}
            //return null;
        }

        public async Task<ApplicationUser> DeleteUser(int id)
        {
            var result = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                 _context.ApplicationUsers.Remove(result);
                 _context.SaveChanges();
                return result;
            }
            return null;
        }
        public async Task<ApplicationUser>GetUserByEmail(string email)
        {
            return await _context.ApplicationUsers.Where(x => x.Email == email).FirstOrDefaultAsync();
            
        }
        public async Task<IEnumerable<ApplicationUser>> Search(string UserName)
        {
            IQueryable<ApplicationUser> query = _context.ApplicationUsers;
            if (!string.IsNullOrEmpty(UserName))
            {
                query = query.Where(o => o.UserName.ToLower().Contains(UserName.Trim().ToLower()));
            }
            return await query.ToListAsync();
        }

        public async Task<ApplicationUser> Profile(ApplicationUser User)
        {
            var result = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == User.Id);
            if (result != null)
            {
                result.UserName = User.UserName;
                result.Email = User.Email;
                result.ContactNo = User.ContactNo;
                result.Address = User.Address;
                result.City = User.City;
                result.State = User.State;
                result.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<ApplicationUser> ForgotPassword(ForgotPasswordViewModel forgetPassword)
        {
            var data = await _context.ApplicationUsers.Where(x => x.Email == forgetPassword.Email).FirstOrDefaultAsync();
            return data;
        }

        public async Task<ApplicationUser> ResetPassword(ResetPasswordViewModel viewModel)
        {
            var user = await _context.ApplicationUsers.Where(x => x.Email == viewModel.Email).FirstOrDefaultAsync();
            if(user!=null)
            {
                user.Password = viewModel.NewPassword;
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersByPaggination(int pageNo, int pageSize)
        {
            List<ApplicationUser> users = await _context.ApplicationUsers.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
            return users;
        }

        public async Task<FeedBack> FeedBack(FeedbackViewModel feedBack)
        {
            FeedBack model = new FeedBack()
            {
                Id = feedBack.Id,
                Email = feedBack.Email,
                FeedbackType = feedBack.FeedbackType,
                Subject = feedBack.Subject,
                UserId = feedBack.UserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            var result = await _context.FeedBacks.AddAsync(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<FeedBack> GetFeedBack(int id)
        {
            var data = await _context.FeedBacks.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<FeedBack>> GetAllFeedBack()
        {
            var data = await _context.FeedBacks.ToListAsync();
            return data;
        }

        public async Task<FeedBack> DeleteFeedback(int id)
        {
            var result = await _context.FeedBacks.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _context.FeedBacks.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
