using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamentos> lista = new List<Departamentos>();
            lista.Add(new Departamentos { Id = 1, Nome = "Eletronicos" });
            lista.Add(new Departamentos { Id = 2, Nome = "Moveis" });

            return View(lista);
        }
    }
}
