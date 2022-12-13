using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SneakerApp.Models
{
    public class Sneaker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Type of Sneaker")]
        public string TypeOfSneaker { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
