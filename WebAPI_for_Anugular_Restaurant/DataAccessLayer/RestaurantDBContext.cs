using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer
{
    public class RestaurantDBContext:DbContext
    {
        public virtual DbSet<tbl_Meals_Category> tbl_Meal_Category { get; set; }


        public RestaurantDBContext()
            : base("RestaurantConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}