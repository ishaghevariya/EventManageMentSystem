using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.Web.Areas.Admin.ViewModel
{
    public class ImageViewModels
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string ImageName { get; set; }
        public string URL { get; set; }
    }
}
