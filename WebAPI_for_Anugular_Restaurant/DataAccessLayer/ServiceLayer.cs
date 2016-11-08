using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_for_Anugular_Restaurant.Models;
using WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer
{
    public class ServiceLayer:IServiceLayer
    {
        private Repository<tbl_Meals_Category> _mealCategory;

        
	
        public Repository<tbl_Meals_Category> MealCategory
        {
            get
            {
                if (_mealCategory == null)
                    _mealCategory = new MealCategoryRepository(new RestaurantDBContext());

                return _mealCategory;
            }
        }
    }
}