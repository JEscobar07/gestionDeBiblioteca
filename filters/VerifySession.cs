using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using gestionBiblioteca.Extensions;
using gestionBiblioteca.Models;
using gestionBiblioteca.Controllers;
using System;

namespace gestionBiblioteca.Filters // Asegúrate de que este namespace es correcto
{
    public class VerifySession : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VerifySession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                var session = _httpContextAccessor.HttpContext.Session;

                var user = session.GetObject<User>("User");
                System.Console.WriteLine("AQUI" + user);
                if (user == null)
                {
                    if (!(filterContext.Controller is AccessController))
                    {
                        filterContext.HttpContext.Response.Redirect("/Access");
                    }
                }

                
            }
            catch (Exception ex)
            {
                // Manejar la excepción o registrar el error
                throw;
            }
        }
    }
}
