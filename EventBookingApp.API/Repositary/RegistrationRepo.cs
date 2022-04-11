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
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public bool GetUserByEmail(string email)
        {
            var isEmaliExist = _context.ApplicationUsers.Any(x => x.Email == email);
            return isEmaliExist;
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
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
