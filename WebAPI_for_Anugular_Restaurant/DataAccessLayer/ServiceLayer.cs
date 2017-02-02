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
        private Repository<tbl_Meals_Category> _CategoryList;
        private Repository<tbl_Sub_Category> _MenuList;


        private RestaurantDBContext _context;

        public ServiceLayer()
        {
            _context = new RestaurantDBContext();
        }
	
        public Repository<tbl_Meals_Category> CategoryList
        {
            get
            {
                if (_CategoryList == null)
                    _CategoryList = new CategoryRepository(_context);

                return _CategoryList;
            }
        }

        public Repository<tbl_Sub_Category> MenuList
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