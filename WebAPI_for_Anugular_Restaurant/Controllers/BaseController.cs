using System;
using System.Web.Http;
using System.Net.Http;
using WebAPI_for_Anugular_Restaurant.DataAccessLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.Controllers
{
    public abstract class BaseController: ApiController
    {
        private IServiceLayer _dataService;

        protected BaseController(IServiceLayer Service)
        {
            _dataService = Service;
        }

        protected IServiceLayer DataService
        {
            get
            {
                return _dataService;
            }
        }

        protected string getUserId(string username)
        {
            ApplicationUserManager UserManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = UserManager.FindByName(username);
            String userId = user.Id;

            return userId;
        }

    }
}