using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_for_Anugular_Restaurant.DataAccessLayer;
using WebAPI_for_Anugular_Restaurant.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;


namespace WebAPI_for_Anugular_Restaurant.Controllers
{
    //[Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController(IServiceLayer serviceLayer)
            : base(serviceLayer)
        {

        }

        public IHttpActionResult Get()
        {
            List<tbl_user_profile> ProfileList = DataService.ProfileManager.Get();
            return Ok(ProfileList);
        }

        public IHttpActionResult Get(string username)
        {
            String userID = getUserId(username);
            tbl_user_profile profile = DataService.ProfileManager.Get_User_Profile(userID);

            ProfileViewModel vm = new ProfileViewModel();
            vm.PhoneNumber = profile.PhoneNumber;
            vm.Address = profile.Address;

            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.First(c => c.Id == userID);
                vm.FirstName = user.FirstName;
                vm.LastName = user.LastName;
            }
            if(profile==null)
                return NotFound();

            return Ok(vm);
        }

        public IHttpActionResult Post(tbl_user_profile profile)
        {
            DataService.ProfileManager.Insert(profile);
            return Created("", profile);
        }

        public IHttpActionResult Put(tbl_user_profile profile)
        {
            DataService.ProfileManager.Update(profile);
            return Ok(profile);
        }

        public IHttpActionResult Delete(int id)
        {
            tbl_user_profile profile = DataService.ProfileManager.Get(id);
            if(profile==null)
                return NotFound();

            DataService.ProfileManager.Delete(profile);
            return Ok();
        }

             
    }
}
