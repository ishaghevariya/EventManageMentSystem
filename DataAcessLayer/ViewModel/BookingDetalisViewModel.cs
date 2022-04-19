using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.ViewModel
{
   public class BookingDetalisViewModel
    {
        public int BookingDetalisId { get; set; }
        public int BookingId { get; set; }
        public string EquipmentType { get; set; }
        public int EquipmentId { get; set; }
        public string FoodType { get; set; }
        public int FoodId { get; set; }
        public string FlowerType { get; set; }
        public int FlowerId { get; set; }
    }
}
