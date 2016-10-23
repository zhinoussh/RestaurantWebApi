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
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.Controllers
{
    public class MealCategoryController : ApiController
    {
        private RestaurantDBContext db = new RestaurantDBContext();

        // GET: api/tbl_Meals_Category
        public IQueryable<tbl_Meals_Category> Get()
        {
            return db.tbl_Meal_Category;
        }

        // GET: api/tbl_Meals_Category/5
        [ResponseType(typeof(tbl_Meals_Category))]
        public IHttpActionResult Get(int id)
        {
            tbl_Meals_Category meal = db.tbl_Meal_Category.Find(id);
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        // PUT: api/tbl_Meals_Category/5
        [ResponseType(typeof(void))]
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
                if (!tbl_Meals_CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tbl_Meals_Category
        [ResponseType(typeof(tbl_Meals_Category))]
        public IHttpActionResult Post(tbl_Meals_Category meal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Meal_Category.Add(meal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meal.pkey }, meal);
        }

        // DELETE: api/tbl_Meals_Category/5
        [ResponseType(typeof(tbl_Meals_Category))]
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Meals_CategoryExists(int id)
        {
            return db.tbl_Meal_Category.Count(e => e.pkey == id) > 0;
        }
    }
}