using CMSWebUI.Data.CachedData;
using CMSWebUI.Models.ShopModels;
using CMSWebUI.Models.ShopModels.ShopViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;

namespace CMSWebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly Product ProductModel;
        private readonly Category CategoryModel;
        //readonly ProductCategoryViewModel productCategoryViewModel;
        private readonly ShopDataCache dataCache;
        private readonly IWebHostEnvironment webhostEnvironment;
        public ShopController(IWebHostEnvironment environment)
        {
            dataCache = new ShopDataCache();
            webhostEnvironment = environment;
            //productCategoryViewModel = new ProductCategoryViewModel();
            ProductModel = new Product();
            CategoryModel = new Category();
        }

        [HttpGet]
        public ViewResult ProductList()
        {
            //var viewModel = new ProductsViewModel()
            //{
            //    Products = dataCache.GetProducts(),
            //    Categories = dataCache.GetCategories().AsEnumerable()
            //};
            return View(dataCache.GetProducts());
        }


        [HttpGet]
        public ViewResult AddNewProduct()
        {
            var CategoriesList = dataCache.GetCategories().Select(c => new { c.Id, c.Name }).AsEnumerable();

            var viewModel = new ProductCategoryViewModel()
            {
                Product = ProductModel,
                Categories = new SelectList(CategoriesList, "Id", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNewProduct(ProductCategoryViewModel productVM)
        {
            if (!ModelState.IsValid)
                return View(productVM);


            Product product = new()
            {
                Title = productVM.Product.Title,
                Price = productVM.Product.Price,
                Description = productVM.Product.Description,
                CategoryId = productVM.CategoryId,
                PictureName = string.IsNullOrEmpty(productVM.ProductImage.FileName) == true ? "" : productVM.ProductImage.FileName
            };

            UploadPicture(productVM.ProductImage);

            dataCache.AddNewProduct(product);

            return RedirectToAction("productlist");
        }
        
        [HttpGet]
        public ViewResult Categories()
        {
            return View(dataCache.GetCategories());
        }

        [HttpGet]
        public ViewResult AddNewCategory()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult AddNewCategory(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            dataCache.AddNewCategory(category);
            return RedirectToAction("Categories");
        }

        // GET: ShopController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ProductList));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ProductList));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ProductList));
            }
            catch
            {
                return View();
            }
        }

        #region Helper Methods

        private bool UploadPicture(IFormFile picture)
        {
            try
            {
                string uniqueFileName = GetUniqueFileName(picture.FileName);
                string uploadPath = Path.Combine(webhostEnvironment.WebRootPath, "Uploads");
                string filePath = Path.Combine(uploadPath, uniqueFileName);
                picture.CopyTo(new FileStream(filePath, FileMode.CreateNew));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + DateTime.Now.ToString("yyyyMMddHHmmssffff")
                      + Path.GetExtension(fileName);
        }
        #endregion
    }
}
