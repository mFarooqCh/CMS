using System;
using System.ComponentModel.DataAnnotations;

namespace CMSWebUI.Models.ShopModels
{
    public class Product
    {
        public string Id { get; set; }

        [StringLength(100)]
        [Display(Name ="Product Title")]
        [Required]
        public string Title { get; set; }

        [Range(0,1000)]        
        public string Price { get; set; }
        public string Category { get; set; } 
        public string Description { get; set; }
        public string Image { get; set; }

        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
