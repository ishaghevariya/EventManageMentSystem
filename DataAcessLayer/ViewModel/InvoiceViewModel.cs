using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.ViewModel
{
    public class InvoiceViewModel
    {
        public int EventId { get; set; }
        public int EventCost { get; set; }
        public string EventName { get; set; }
        public int BookingId { get; set; }
        public int BookingDetalisId { get; set; }
        public int FlowerId { get; set; }
        public int FlowerCost { get; set; }
        public int FoodId { get; set; }
        public int FoodCost { get; set; }
        public int EquipmentId { get; set; }
        public int EquipmentCost { get; set; }
        public int total { get; set; }
    }
}
