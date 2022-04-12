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
        public int EventCost { get; set; }
     
    }
}
