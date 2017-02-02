using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories
{
    public class CategoryRepository: Repository<tbl_Meals_Category>
    {
        public CategoryRepository(RestaurantDBContext context)
            : base(context)
        {

        }

         
    }
}