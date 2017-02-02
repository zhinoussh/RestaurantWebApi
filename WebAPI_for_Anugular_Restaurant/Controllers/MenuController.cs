using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_for_Anugular_Restaurant.DataAccessLayer;
using WebAPI_for_Anugular_Restaurant.Filters;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.Controllers
{
    public class MenuController : BaseController
    {
        public MenuController(IServiceLayer serviceLayer)
            : base(serviceLayer)
        {

        }

        public IHttpActionResult Get()
        {
          List<tbl_Sub_Category> menuList=DataService.MenuList.Get();
          return Ok(menuList);
        }

        public IHttpActionResult Get(int id)
        {
            tbl_Sub_Category menuItem = DataService.MenuList.Get(id);
            if (menuItem == null)
                return NotFound();

            return Ok(menuItem);
        }

        [ModelValidator]
        public IHttpActionResult Post(tbl_Sub_Category MenuItem)
        {
            DataService.MenuList.Insert(MenuItem);
            return Created("", MenuItem);
        }

        [ModelValidator]
        public IHttpActionResult Put(tbl_Sub_Category MenuItem)
        {
            DataService.MenuList.Update(MenuItem);
            return Ok(MenuItem);
        }

        [ModelValidator]
        public IHttpActionResult Delete(int id)
        {
            tbl_Sub_Category menuItem = DataService.MenuList.Get(id);
            if (menuItem == null)
                return NotFound();

            DataService.MenuList.Delete(menuItem);
            return Ok();
        
        }
    }
}
