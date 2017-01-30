using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories
{
    public class MealCategoryRepository: Repository<tbl_Meals_Category>
    {
        public MealCategoryRepository(RestaurantDBContext context)
            : base(context)
        {

        }

         
    }
}