using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories
{
    public class MenuRepository:Repository<tbl_Sub_Category>
    {
        public MenuRepository(RestaurantDBContext _context)
            :base(_context)
        {
                
        }
    }
}