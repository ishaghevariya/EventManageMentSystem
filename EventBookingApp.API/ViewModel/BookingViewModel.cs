using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.ViewModel
{
    public class BookingViewModel
    {
        [Required(ErrorMessage ="Please Select EventDate")]
        public DateTime EventDate { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        public int BookingStatusId { get; set; }
        [Required(ErrorMessage = "Please Enter AreaPincode")]
        public int AreapinCode { get; set; }
        [Required(ErrorMessage = "Please Select VenuType")]
        public string VenuType { get; set; }
        [Required(ErrorMessage = "Please Enter NumberOfPerson")]
        public int NumberOfPerson { get; set; }
        [Required(ErrorMessage = "Please Enter NumberofDays")]
        public int NumberOfDays { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
