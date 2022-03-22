using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodType { get; set; }
        public int FoodCost { get; set; }
        public ICollection<BookingDetalis> BookingDetalis { get; set; } = new HashSet<BookingDetalis>();
    }
}
