using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


using gestionBiblioteca.filters; // Ajusta el espacio de nombres si es necesario

namespace gestionBiblioteca.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerifySession()); // Usa la clase correcta
        }
    }
}
