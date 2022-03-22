﻿using Microsoft.AspNetCore.Identity;
using System;

namespace DataAcessLayer
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string UserRole { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}