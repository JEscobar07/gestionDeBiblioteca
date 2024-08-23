using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


using gestionBiblioteca.Data;

namespace gestionBiblioteca.Controllers
{
    [Route("[controller]")]
    public class AccessController : Controller
    {
         //base de datos
        private readonly Bfkxytwn9bgzdtfvozeuContext _context;

        public AccessController(Bfkxytwn9bgzdtfvozeuContext context)
        {
            _context = context;
        }

        //get access
        public ActionResult Login()
        {
            return View();
        }

        //Post: access/login
        [HttpPost]
        public ActionResult Login(string user,string password)
        {
            try
            {   
                var oUser = _context.Users
                            .Where(d=> d.Email == user.Trim() && d.Password.Trim() == password.Trim()).Select(d=>d).FirstOrDefault();
                    // System.Console.WriteLine(oUser.GetType());
                if (oUser == null)
                {
                    // ViewBag es un diccionario que se obtiene desde la vista que maneja un error
                    ViewBag.Error = "¡Usuario o password invalido!";
                    return View();
                }
                
               
                
                //objeto llamado seccion es un arreglo donde guardo en este objeto el usuario existente
                //Session["User"] = oUser;

                //donde me redirecciona si si encuentra 
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw new  Exception ("error al ingresar usuario"+ ex);
                //Manejar la excepcion 
                ViewBag.Error = "Ha ocurrido un error"+ ex.Message;
                return View();
            }

        }
    }
}