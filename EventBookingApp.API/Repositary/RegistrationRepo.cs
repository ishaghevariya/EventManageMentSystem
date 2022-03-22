using DataAcessLayer;
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

        public Task<ApplicationUser> Login(string email, string password)
        {
            throw new NotImplementedException();
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
    }
}
