using System;

namespace DataAcessLayer
{
    public class EventGallery
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string ImageName { get; set; }
        public string URL { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Event Event { get; set; }
    }
}