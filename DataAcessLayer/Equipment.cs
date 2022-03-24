using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        [Required(ErrorMessage = "EquipmentType is required")]
        public string EquipmentType { get; set; }
        [Required(ErrorMessage ="EquipmentCost is required")]
        public int EquipmentCost { get; set; }
        public ICollection<BookingDetalis> BookingDetalis { get; set; } = new HashSet<BookingDetalis>();
    }
}
