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
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "EquipmentCost is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int EquipmentCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<BookingDetalis> BookingDetalis { get; set; } = new HashSet<BookingDetalis>();
    }
}
