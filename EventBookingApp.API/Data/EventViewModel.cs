using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Data
{
    public class EventViewModel
    {
        public string EventTypes { get; set; }
        public IFormFile Images { get; set; }
      
    }
}
