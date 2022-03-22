using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class Event
    {
        public int Id { get; set; }
        public string EventTypes { get; set; }
        public string Images { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
