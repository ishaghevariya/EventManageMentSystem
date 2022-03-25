using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class Food
    {
        public int FoodId { get; set; }
        [Required(ErrorMessage = "FoodType is required")]
        public string FoodType { get; set; }
        [Required(ErrorMessage = "FoodCost is required")]
        public int FoodCost { get; set; }
        public ICollection<BookingDetalis> BookingDetalis { get; set; } = new HashSet<BookingDetalis>();
    }
}
