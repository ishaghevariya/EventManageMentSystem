using DataAcessLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventGallery> EventGalleries { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetalis> BookingDetalis  { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
