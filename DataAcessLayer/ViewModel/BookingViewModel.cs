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
        public string VenuType { get; set; }
        [Required(ErrorMessage = "Please Enter NumberOfPerson")]
        public int NumberOfPerson { get; set; }
        [Required(ErrorMessage = "Please Enter NumberofDays")]
        public int NumberOfDays { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please Select Event")]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Status { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            if (EventDate <= DateTime.Today.AddDays(3))
            {
                ValidationResult mss = new ValidationResult("Event date must be 2 day after");
                res.Add(mss);
            }
            return res;
        }
    }
}
