using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;

namespace WebAPI_for_Anugular_Restaurant.Filters
{
    public class ModelValidatorAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if(!actionContext.ModelState.IsValid)
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            
            base.OnActionExecuting(actionContext);
        }
    }
}