using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories
{
    public class MenuRepository:Repository<tbl_Sub_Category>
    {
        RestaurantDBContext context;
        public MenuRepository(RestaurantDBContext _context)
            :base(_context)
        {
            context = _context;    
        }

        public List<tbl_Sub_Category> Get_Menu_In_Category(int id)
        {
            return context.tbl_Sub_Category.Where(x => x.CategoryID == id).ToList();
        }
    }
}