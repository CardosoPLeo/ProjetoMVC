using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC.Data;
using CRUDMVC.Models;

namespace CRUDMVC.Services
{
    public class ServicoDepartamento
    {
        private readonly CRUDMVCContext _context;

        public ServicoDepartamento(CRUDMVCContext context)
        {
            _context = context;
        }

        public List<Departamentos> LocalizarTodos()
        {
            return _context.Departamentos.OrderBy(x => x.Nome).ToList();
        }
    }
}
