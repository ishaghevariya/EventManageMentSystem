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
        public int Id { get; set; }
        [Required(ErrorMessage = "FlowerType is Required")]
        public string FlowerType { get; set; }
        public string FileName { get; set; }
        public IFormFile FlowerImage { get; set; }
        [Required(ErrorMessage = "FlowerCost is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int FlowerCost { get; set; }
    }
}
