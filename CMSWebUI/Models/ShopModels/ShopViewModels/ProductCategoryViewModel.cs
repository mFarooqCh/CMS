using System.Collections.Generic;

namespace CMSWebUI.Models.ShopModels.ShopViewModels
{
    public class ProductCategoryViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}
