namespace SmartphoneStore.Web.Models
{
    using System.Collections.Generic;

    public class SmartphoneDetailsViewModel
    {
        public int Id { get; set; }
        
        public string Model { get; set; }
        
        public double MonitorSize { get; set; }
        
        public double RamMemorySize { get; set; }
        
        public string ImageUrl { get; set; }
        
        public decimal Price { get; set; }

        public string Description { get; set; }
        
        public string ManufacturerName { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}