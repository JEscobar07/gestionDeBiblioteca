using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using gestionBiblioteca.Data;
using Microsoft.AspNetCore.Http; // Necesario para usar HttpContext.Session

namespace gestionBiblioteca.Controllers
{
    [Route("[controller]")]
    public class AccessController : Controller
    {
        // Base de datos
        private readonly Bfkxytwn9bgzdtfvozeuContext _context;

        public AccessController(Bfkxytwn9bgzdtfvozeuContext context)
        {
            _context = context;
        }

        // GET: /access/login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /access/login
        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            try
            {   
                var oUser = _context.Users
                            .Where(d => d.Email == user.Trim() && d.Password.Trim() == password.Trim())
                            .FirstOrDefault();

                if (oUser == null)
                {
                    // ViewBag es un diccionario que se obtiene desde la vista que maneja un error
                    ViewBag.Error = "¡Usuario o contraseña inválido!";
                    return View();
                }
                
                // Guardar el usuario en la sesión
                HttpContext.Session.SetString("User", oUser.Email); // Puedes guardar el Email o algún identificador único

                // Redirigir a la página principal
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                ViewBag.Error = "Ha ocurrido un error: " + ex.Message;
                return View();
            }
        }
    }
}

