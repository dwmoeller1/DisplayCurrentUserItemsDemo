using System;
using System.Collections.Generic;
using System.Text;
using DisplayCurrentUserItemsDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DisplayCurrentUserItemsDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories;
        public DbSet<UserCategory> UserCategories;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
