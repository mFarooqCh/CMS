using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CMSWebUI.Models.ShopModels;

namespace CMSWebUI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CMSWebUI.Models.ShopModels.Product> Product { get; set; }
        public DbSet<CMSWebUI.Models.ShopModels.Category> Category { get; set; }
    }
}
