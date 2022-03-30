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
        public async Task<ApplicationUser> changePassword(ChangePasswordModel chagePassword)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Email == chagePassword.Email);
            if (user != null)
            {
                user.Password = chagePassword.NewPassword;
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public int SignInMethod(string email, string password)
        {
            var result = _context.ApplicationUsers.Where(x => x.Email == email && x.Password == password).Count();
           
            return result;
        }
        public async Task<ApplicationUser> UserRegistration(ApplicationUser applicationUser)
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
                State = applicationUser.State
            };
            var result = await _context.ApplicationUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //public async Task<ApplicationUser> GetUserByEmail(string email)
        //{
        //    return await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Email == email);
        //}
    }
}
