using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class Event
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="EventType is required")]
        public string EventTypes { get; set; }
        public string Images { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
