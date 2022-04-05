using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcessLayer
{
    public class ApplicationUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password should be grater then 8 character")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [RegularExpression(@"^([a-z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNo { get; set; }
        public string UserRole { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    }
}
