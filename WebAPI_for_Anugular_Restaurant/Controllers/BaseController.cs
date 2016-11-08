using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI_for_Anugular_Restaurant.DataAccessLayer;

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
    }
}