using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class BookingStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
