using System;
using System.ComponentModel.DataAnnotations;

namespace CMSWebUI.Models.ShopModels
{
    public class Category
    {
        public string Id { get; set; }

        [Display(Name ="Category Title")]
        [StringLength(150)]
        public string Name { get; set; }

        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
