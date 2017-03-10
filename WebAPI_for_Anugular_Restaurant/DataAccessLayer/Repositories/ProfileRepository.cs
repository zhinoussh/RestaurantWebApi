using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories
{
    public class ProfileRepository: Repository<tbl_user_profile>
    {
        RestaurantDBContext context;

        public ProfileRepository(RestaurantDBContext _context)
            :base(_context)
        {
            context = _context;
        }

        public tbl_user_profile Get_User_Profile(string userId)
        {
            return context.tbl_user_profile.Where(x => x.UserID == userId).FirstOrDefault();
        }

    }
}