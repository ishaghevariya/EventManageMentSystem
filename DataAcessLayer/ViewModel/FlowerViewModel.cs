using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.ViewModel
{
    public class FlowerViewModel
    {
        [Required(ErrorMessage = "FlowerType is Required")]
        public string FlowerType { get; set; }
        public IFormFile FlowerImage { get; set; }
        [Required(ErrorMessage = "FlowerCost is Required")]
        public int FlowerCost { get; set; }
    }
}
