using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI_for_Anugular_Restaurant.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using System.Net.Http;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories
{
    public class ProfileRepository : Repository<tbl_user_profile>
    {
        RestaurantDBContext context;

        public ProfileRepository(RestaurantDBContext _context)
            : base(_context)
        {
            context = _context;
        }

        public ProfileViewModel Get_User_Profile(string username, ApiController ctrl)
        {
            ProfileViewModel vm = null;

            string userId = getUserId(username,ctrl);
            tbl_user_profile profile = context.tbl_user_profile.Where(x => x.UserID == userId).FirstOrDefault();

            if (profile != null)
            {
                vm = new ProfileViewModel();
                vm.PhoneNumber = profile.PhoneNumber;
                vm.Address = profile.Address;
                

                using (var db = new ApplicationDbContext())
                {
                    var user = db.Users.First(c => c.Id == userId);
                    vm.FirstName = user.FirstName;
                    vm.LastName = user.LastName;
                    vm.UserName = user.UserName;
                }
            }
            return vm;
        }

        public tbl_user_profile Insert(ProfileViewModel vm, string username, ApiController ctrl)
        {
            string userId = getUserId(username, ctrl);

            tbl_user_profile profile = new tbl_user_profile();
            profile.Address = vm.Address;
            profile.PhoneNumber = vm.PhoneNumber;
            profile.UserID = userId;
            Insert(profile);

            UpdateUser(vm, userId);

            return profile;
        }

        public tbl_user_profile Update(ProfileViewModel vm, string username, ApiController ctrl)
        {
            string userId = getUserId(username, ctrl);

            tbl_user_profile profile = context.tbl_user_profile.Where(x => x.UserID == userId).FirstOrDefault();
            profile.Address = vm.Address;
            profile.PhoneNumber = vm.PhoneNumber;
            Update(profile);

            UpdateUser(vm, userId);

            return profile;
        }

        private string getUserId(string username, ApiController ctrl)
        {
            ApplicationUserManager UserManager =ctrl.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = UserManager.FindByName(username);
            String userId = user.Id;

            return userId;
        }

        private static void UpdateUser(ProfileViewModel vm, string userId)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.First(x => x.Id == userId);
                user.FirstName = vm.FirstName;
                user.LastName = vm.LastName;
                user.UserName = vm.UserName;
                user.Email = vm.UserName;
                db.SaveChanges();
            }
        }
    }


}