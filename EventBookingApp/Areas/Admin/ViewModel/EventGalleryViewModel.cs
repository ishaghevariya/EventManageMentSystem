using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.Web.Areas.Admin.ViewModel
{
    public class EventGalleryViewModel
    {
        public int EventId { get; set; }
        public string ImageName { get; set; }
        public string URL { get; set; }
        public IList<IFormFile> Images { get; set; }
    }
}
