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
    public class UserController : Controller
    {
        private readonly Bfkxytwn9bgzdtfvozeuContext _context;

        public UserController(Bfkxytwn9bgzdtfvozeuContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> CreateUser()
        {
            var roles = await _context.Roles.ToListAsync();
            return View(roles);
        }

    }
}