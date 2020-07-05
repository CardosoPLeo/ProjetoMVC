using System;
using CRUDMVC.Data;
using CRUDMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUDMVC.Services
{
    public class ServicoRegistroDeVendas
    {
        private readonly CRUDMVCContext _context;
        public ServicoRegistroDeVendas(CRUDMVCContext context)
        {
            _context = context;
        }

        public async Task <List<RegistroDeVendas>> BuscaPorDataAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.RegistroDeVendas select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= maxDate.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamentos)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        
        public async Task<List<IGrouping<Departamentos, RegistroDeVendas>>> BuscaPorDataAgrupadaAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.RegistroDeVendas select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= maxDate.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamentos)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamentos)
                .ToListAsync();
        }

    }

}
