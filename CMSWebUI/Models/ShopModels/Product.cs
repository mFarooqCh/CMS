using System;
using System.ComponentModel.DataAnnotations;

namespace CMSWebUI.Models.ShopModels
{
    public class Product
    {
        public string Id { get; set; }

        [StringLength(100)]
        [Display(Name ="Product Name")]
        [Required]
        public string Title { get; set; }

        [Range(0,1000)]        
        public string Price { get; set; }

        public string CategoryId { get; set; }

        public string Description { get; set; }

        [Display(Name ="Product Pic")]
        public string PictureName { get; set; }

        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
