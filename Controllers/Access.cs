using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//base de datos 
using gestionBiblioteca.Models;

namespace gestionDeBiblioteca.Controllers
{
    [Route("[controller]")]
    public class Access : Controller
    {
        //base de datos
        private readonly Bfkxytwn9bgzdtfvozeuContext _context;

        public Access(Bfkxytwn9bgzdtfvozeuContext context)
        {
            _context = context;
        }

        //get access
        public IActionResult Login()
        {
            return View();
        }

        //Post: access/login
        [HttpPost]

        public IActionResult Login(string user,string password)
        {
            try
            {
                var oUser = _context.Users
                            .Where(d=> d.Email == user.Trim() && d.Password.Trim() == password.Trim())
                            .FirstOrDefault();

                if (oUser == null)
                {
                    // ViewBag es un diccionario que se obtiene desde la vista que maneja un error
                    ViewBag.Error = "¡Usuario o password invalido!";
                    return View();
                }

                //objeto llamado seccion es un arreglo donde ingreso elementos que deseo
                //guardo en este objeto el usuario existente
                //Session["User"] = oUser;

                //donde me redirecciona si si encuentra 
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                //Manejar la excepcion 
                ViewBag.Error = "Ha ocurrido un error"+ ex.Message;
                return View();
            }

        }
    }
}