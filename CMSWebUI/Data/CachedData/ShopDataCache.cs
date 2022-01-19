using CMSWebUI.Models.ShopModels;
using CMSWebUI.Models.ShopModels.ShopViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace CMSWebUI.Data.CachedData
{
    public class ShopDataCache
    {
        readonly ObjectCache cache = MemoryCache.Default;
        readonly List<Product> products;
        readonly List< Category> categories;

        public ShopDataCache()
        {
            products = cache["products"] as List<Product>;
            categories =  cache["categories"] as List<Category>;

            if (products == null)
                products = new();

            if (categories == null)
                categories = new();
        }
        public List<Product> GetProducts()
        {
            return products;
        }

        public void AddNewProduct(Product product)
        {
            products.Add(product);
            cache["products"] = products;
        }

        public void AddNewCategory(Category category)
        {
            categories.Add(category);
            cache["categories"] = categories;
        }

        public List<Category> GetCategories()
        {
            return categories;
        }



    }
}
