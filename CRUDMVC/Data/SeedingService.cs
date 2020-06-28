using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using CRUDMVC.Models;
using CRUDMVC.Models.Enums;

namespace CRUDMVC.Data
{
    public class SeedingService
    {
        private CRUDMVCContext _context;

        public SeedingService(CRUDMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamentos.Any()||
                _context.Vendedor.Any()||
                _context.RegistroDeVendas.Any())
            {
                return;//DB já foi populado
            }

            Departamentos dep1 = new Departamentos(1, "Compuatdores");
            Departamentos dep2 = new Departamentos(2, "Eletrônicos");
            Departamentos dep3 = new Departamentos(3, "Games");
            Departamentos dep4 = new Departamentos {Id = 4, Nome = "Celulares" };

            Vendedor vnd1 = new Vendedor(1, "Bob 1", "bob@gmail.com", new DateTime(1988, 4, 1), 1000.0, dep1);
          

            RegistroDeVendas rg = new RegistroDeVendas(1, new DateTime(2020,6, 28), 5000.0, StatusDaVenda.Faturado, vnd1);

            _context.Departamentos.AddRange(dep1, dep2, dep3, dep4);
            _context.Vendedor.AddRange(vnd1);
            _context.RegistroDeVendas.AddRange(rg);

            _context.SaveChanges();

        }
    }
}
