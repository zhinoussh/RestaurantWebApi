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

        public IHttpActionResult Put(int id, tbl_Meals_Category updated_meal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updated_meal.pkey)
            {
                return BadRequest();
            }

           // db.Entry(updated_meal).State = EntityState.Modified;

            try
            {
                tbl_Meals_Category original_meal=db.tbl_Meal_Category.Find(id);
                if (original_meal != null)
                {
                    original_meal.meal_name = updated_meal.meal_name;
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!tbl_Meals_CategoryExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return StatusCode(HttpStatusCode.NoContent);
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