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
        private CategoryRepository _CategoryList;
        private MenuRepository _MenuList;


        private RestaurantDBContext _context;

        public ServiceLayer()
        {
            _context = new RestaurantDBContext();
        }

        public CategoryRepository CategoryList
        {
            get
            {
                if (_CategoryList == null)
                    _CategoryList = new CategoryRepository(_context);

                return _CategoryList;
            }
        }

        public MenuRepository MenuList
        {
            get {
                if (_MenuList == null)
                    _MenuList = new MenuRepository(_context);

                return _MenuList;
            }
        }
        public void test()
        {
           // _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('tbl_Meals_Category', RESEED, 0)");
        }


      

    }
}