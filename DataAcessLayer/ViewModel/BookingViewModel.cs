using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.ViewModel
{
    public class BookingViewModel: IValidatableObject
    {
        [Required(ErrorMessage = "Please Select EventType")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select EventDate")]
        [DataType(DataType.Date)]
        //[DateLessThanOrEqualToToday]
        public DateTime EventDate { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        public int BookingStatusId { get; set; }
        [Required(ErrorMessage = "Please Enter AreaPincode")]
        public int AreapinCode { get; set; }
        [Required(ErrorMessage = "Please Select VenuType")]
        public string VenueType { get; set; }
        [Required(ErrorMessage = "Please Enter NumberOfPerson")]
        public int NumberOfPerson { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime EventTime { get; set; }
        public int IsCancel { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please Select Event")]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Status { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            if (FromDate <= DateTime.Today.AddDays(2))
            {
                ValidationResult mss = new ValidationResult("FromDate must be 2 day afters date");
                res.Add(mss);
            }
            //if (ToDate <= DateTime.Today.AddDays(2))
            //{
            //    ValidationResult mss = new ValidationResult("ToDate must be 2 day afters date");
            //    res.Add(mss);
            //}
            if(ToDate < FromDate)
            {
                ValidationResult mss = new ValidationResult("Todate is not less than FromDate");
                res.Add(mss);
            }
            return res;
        }
    }
}
