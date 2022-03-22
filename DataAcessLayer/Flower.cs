using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class Flower
    {
        public int FlowerId { get; set; }
        public string FlowerType { get; set; }
        public string FlowerImage { get; set; }
        public int FlowerCost { get; set; }
        public ICollection<BookingDetalis> BookingDetalis { get; set; } = new HashSet<BookingDetalis>();
    }
}
