﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.ViewModel
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FeedbackType is required")]
        public string FeedbackType { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
        public int UserId { get; set; }
    }
}