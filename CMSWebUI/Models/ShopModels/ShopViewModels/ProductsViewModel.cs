using System.Collections.Generic;

namespace CMSWebUI.Models.ShopModels.ShopViewModels
{
    public class ProductsViewModel
    {
        public Product Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        //public string Picture { get; set; }
    }
}
