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
    [Authorize]
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
            ProfileViewModel profile = DataService.ProfileManager.Get_User_Profile(username,this);

            if (profile == null)
                return NotFound();

            return Ok(profile);
        }

        public IHttpActionResult Post(ProfileViewModel profile, string username)
        {
            if (Get(username) == NotFound())
            {
                tbl_user_profile user_profile = DataService.ProfileManager.Insert(profile, username, this);
                return Created("", user_profile);
            }
            else
                return Put(profile, username);
        }

        public IHttpActionResult Put(ProfileViewModel profile, string username)
        {
            DataService.ProfileManager.Update(profile, username, this);
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
