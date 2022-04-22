using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string FeedbackType { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
