using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.ViewModel
{
    public class EventViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="EventType is Required")]
        public string EventTypes { get; set; }
        [Required(ErrorMessage = "EventType is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int EventCost { get; set; }
     
    }
}
