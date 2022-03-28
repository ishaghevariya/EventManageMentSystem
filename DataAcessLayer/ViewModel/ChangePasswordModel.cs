using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.ViewModel
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Email Is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage ="Confirm Password Is required")]
        [Compare("NewPassword", ErrorMessage = "NewPassword And ConfirmPassword Must be Same")]
        public string ConfirmPassword { get; set; }

    }
}
