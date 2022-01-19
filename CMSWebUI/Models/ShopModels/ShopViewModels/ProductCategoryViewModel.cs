using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMSWebUI.Models.ShopModels.ShopViewModels
{
    public class ProductCategoryViewModel
    {
        public Product Product { get; set; }

        public SelectList Categories { get; set; }
        
        [Required]
        [Display(Name ="Category Name")]
        public string CategoryId { get; set; }

        [Display(Name ="Product Pic")]
        public IFormFile ProductImage { get; set; }

    }
}
