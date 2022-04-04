using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.ViewModel
{
    public class BookingViewModel
    {
        public DateTime EventDate { get; set; }
        public string Address { get; set; }
        public int BookingStatusId { get; set; }
        public int AreapinCode { get; set; }
        public string VenuType { get; set; }
        public int NumberOfPerson { get; set; }
        public int NumberOfDays { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
