using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.Web.Areas.Admin.ViewModel
{
    public class EventViewModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "EventType is Required")]
        public string EventTypes { get; set; }
        [Required(ErrorMessage = "EventType is Required")]
        public int EventCost { get; set; }
        public IList<IFormFile> images { get; set; }
    }
}
