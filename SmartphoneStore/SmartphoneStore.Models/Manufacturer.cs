namespace SmartphoneStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        private ICollection<Smartphone> smartphones;

        public Manufacturer()
        {
            this.smartphones = new HashSet<Smartphone>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Smartphone> Smartphones
        {
            get { return this.smartphones; }
            set { this.smartphones = value; }
        }
    }
}
