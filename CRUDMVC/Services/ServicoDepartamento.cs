using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC.Data;
using CRUDMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDMVC.Services
{
    public class ServicoDepartamento
    {
        private readonly CRUDMVCContext _context;

        public ServicoDepartamento(CRUDMVCContext context)
        {
            _context = context;
        }

        public async Task <List<Departamentos>> LocalizarTodosAsync()
        {
            return await _context.Departamentos.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
