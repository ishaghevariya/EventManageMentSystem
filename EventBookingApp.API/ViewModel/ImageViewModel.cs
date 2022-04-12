using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.ViewModel
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public int  EventId { get; set; }
        public string ImageName { get; set; }
        public string URL { get; set; }
    }
}
