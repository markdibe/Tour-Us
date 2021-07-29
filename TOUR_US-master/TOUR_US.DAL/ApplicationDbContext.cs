using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TOUR_US.DAL.Models;

namespace TOUR_US.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-9V9T1CN\\LOCALDB#D1EB2882;Database=aspnet-TEST-0C0AF18E-1516-4FDA-A0EF-8518DFFFDE25;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder); 
        }


        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryImage> CategorieImages { get; set; }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityImage> ActivityImages { get; set; }

        public virtual DbSet<VoucheredActivity> VoucheredActivities { get; set; }

        public virtual DbSet<VoucherImage> VoucherImages { get; set; }

    }
}
