using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using gestionBiblioteca.Models;
using gestionBiblioteca.Controllers;

namespace gestionBiblioteca.filters
{
    public class VerifySession : ActionFilterAttribute
    {
        private User oUser;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActtionExecuting(filterContext);
                oUser = (usuario)HttpContext.Current.Session["User"];
                if(oUser == null){
                    if(filterContext.Controller is AccessController == false){
                        filterContext.HttpContext.Response.Redirect("/Access/Login");
                    }
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        
    }
}