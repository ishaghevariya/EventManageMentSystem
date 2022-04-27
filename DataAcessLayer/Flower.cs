using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class Flower
    {
        public int FlowerId { get; set; }
        [Required(ErrorMessage ="Flower Type is required")]
        public string FlowerType { get; set; }
        public string FlowerImage { get; set; }
        [Required(ErrorMessage = "Flowercost is required")]
        public int FlowerCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<BookingDetalis> BookingDetalis { get; set; } = new HashSet<BookingDetalis>();
    }
}
