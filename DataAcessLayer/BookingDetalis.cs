using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class BookingDetalis
    {
        public int BookingDetalisId { get; set; }
        public int BookingId { get; set; }
        public int EquipmentId { get; set; }
        public int FoodId { get; set; }
        public int FlowerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
    }
}
