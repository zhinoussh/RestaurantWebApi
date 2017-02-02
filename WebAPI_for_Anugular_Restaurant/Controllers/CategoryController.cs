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
    public class CategoryController : BaseController
    {

        public CategoryController(IServiceLayer serviceLayer):base(serviceLayer)
        {
        }
        
        public IHttpActionResult Get()
        {
            var categories = DataService.CategoryList.Get();
            return Ok(categories);
        }

        public IHttpActionResult Get(int id)
        {
            var category = DataService.CategoryList.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [ModelValidator]
        public IHttpActionResult Put(tbl_Meals_Category meal)
        {
            var updated_meal = DataService.CategoryList.Update(meal);
           return Ok(updated_meal);
        }

        [ModelValidator]
        public IHttpActionResult Post(tbl_Meals_Category cat)
        {

            var created_cat = DataService.CategoryList.Insert(cat);
            
          return Created("", created_cat);
        }

        public IHttpActionResult Delete(int id)
        {
            tbl_Meals_Category meal = DataService.CategoryList.Get(id);
            if (meal == null)
            {
                return NotFound();
            }

            DataService.CategoryList.Delete(meal);
            
            return Ok();
        }

    }
}