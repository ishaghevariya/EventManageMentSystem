using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class Booking
    {
        public int Id{ get; set; }
        public int EventId { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime EventDate { get; set; }
        public int BookingStatusId { get; set; }
        public string Address { get; set; }
        public int AreapinCode { get; set; }
        public int NumberOfPerson { get; set; }
        public string VenuType { get; set; }
        public Event Event { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public ICollection<BookingDetalis> BookingDetalis { get; set; } = new HashSet<BookingDetalis>();
    }
}
