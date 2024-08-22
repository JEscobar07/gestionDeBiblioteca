using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using gestionDeBiblioteca.Data;

namespace gestionDeBiblioteca.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly Bfkxytwn9bgzdtfvozeuContext _context;

        public UserController(Bfkxytwn9bgzdtfvozeuContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(CreateUser);
        }

    }
}