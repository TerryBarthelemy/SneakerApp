using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Sneaker Name")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [Required]
        [Display(Name = "Product Number")]
        public string ProductNumber { get; set; }


        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }


        [ValidateNever]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }



        [Required]
        [Display(Name = "Type of Sneaker")]
        public int SneakerId { get; set; }
        [ForeignKey("SneakerId")]
        [ValidateNever]
        
        public Sneaker Sneaker { get; set; }



        [Required]
        [Display(Name = "Sneaker Size")]
        public int SneakerSizeId { get; set; }
        [ValidateNever]
        
        public SneakerSize Size { get; set; }
    }
}
