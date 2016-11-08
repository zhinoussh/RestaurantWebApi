using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_for_Anugular_Restaurant.DataAccessLayer;
using WebAPI_for_Anugular_Restaurant.Filters;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.Controllers
{
    public class MealCategoryController : ApiController
    {
        private RestaurantDBContext db=new RestaurantDBContext();
        private IServiceLayer _dataService;

        public MealCategoryController()
        {
            _dataService = new ServiceLayer();
        }
        public IHttpActionResult Get()
        {
            var categories = _dataService.MealCategory.Get();
            return Ok(categories);
        }

        public IHttpActionResult Get(int id)
        {
            var category = _dataService.MealCategory.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [ModelValidator]
        public IHttpActionResult Put(tbl_Meals_Category meal)
        {

           var updated_meal= _dataService.MealCategory.Update(meal);
           return Ok(updated_meal);
        }

        [ModelValidator]
        public IHttpActionResult Post(tbl_Meals_Category cat)
        {

          var created_cat= _dataService.MealCategory.Insert(cat);
            
          return Created("", created_cat);
        }

        public IHttpActionResult Delete(int id)
        {
            tbl_Meals_Category tbl_Meals_Category = db.tbl_Meal_Category.Find(id);
            if (tbl_Meals_Category == null)
            {
                return NotFound();
            }

            db.tbl_Meal_Category.Remove(tbl_Meals_Category);
            db.SaveChanges();

            return Ok(tbl_Meals_Category);
        }

    }
}