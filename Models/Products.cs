using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DKMart.Models
{
    public class Products
    {

        [Key]
        public int ProductId { get; set; }
        [Required]
        [DisplayName("Title")]
        public string title { get; set; }
        [Required]
        [DisplayName("Image")]
        public string image { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [DisplayName("Price")]
        public double price { get; set; }
        [Required]
        [DisplayName("Quantity")]
        public int quantity { get; set; }
        [Required]
        [DisplayName("Description")]

        public string quan_grams { get; set; }
        [Required]
        public string DetailImages { get; set; }

        public string DetailImages1 { get; set; }
        public string description { get; set; }
        [Required]
        [DisplayName("WishList")]
        public bool addToWishlist { get; set; }
        [DisplayName("Category Type")]
        public int CatId { get; set; }
        [ForeignKey("CatId")]

        public virtual Category Category { get; set; }
    }
}