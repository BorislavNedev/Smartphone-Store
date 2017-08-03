namespace SmartphoneStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Smartphone
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Smartphone()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }
                
        [Key]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Measure in inches
        /// </summary>
        [Required]
        public double MonitorSize { get; set; }

        /// <summary>
        /// Measured in GB
        /// </summary>
        [Required]
        public double RamMemorySize { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Measured in US Dollars
        /// </summary>
        [Required]
        public decimal Price { get; set; }
        
        public string Description { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
