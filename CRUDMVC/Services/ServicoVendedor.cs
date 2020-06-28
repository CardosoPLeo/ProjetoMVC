using CRUDMVC.Data;
using CRUDMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMVC.Services
{
    public class ServicoVendedor
    {
        private readonly CRUDMVCContext _context;

        public ServicoVendedor(CRUDMVCContext context)
        {
            _context = context;
        }

        public List<Vendedor> LocalizarTodos()
        {
            return _context.Vendedor.ToList();
        }
    }


}
