using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class Booking
    {
        public int Id{ get; set; }
        public int EventId { get; set; }
        public int? UserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime EventTime { get; set; }
        public string Address { get; set; }
        public int BookingStatusId { get; set; }
        public int AreapinCode { get; set; }
        public int NumberOfPerson { get; set; }
        public string VenuType { get; set; }
        public bool IsCancle { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
        public ApplicationUser User { get; set; }
        public Event Event { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public ICollection<BookingDetalis> BookingDetalis { get; set; } = new HashSet<BookingDetalis>();
    }
}
