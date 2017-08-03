namespace SmartphoneStore.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int SmartphoneId { get; set; }

        public virtual Smartphone Smartphone { get; set; }
    }
}
