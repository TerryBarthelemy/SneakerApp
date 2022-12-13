using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerApp.Models
{
    public class SneakerSize
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sneaker Size")]
        [Required]
        public string Size { get; set; }
    }
}
