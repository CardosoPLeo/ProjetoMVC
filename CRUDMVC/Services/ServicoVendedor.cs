using CRUDMVC.Data;
using CRUDMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
using CRUDMVC.Services.Exceptions;

namespace CRUDMVC.Services
{
    public class ServicoVendedor
    {
        private readonly CRUDMVCContext _context;

        public ServicoVendedor(CRUDMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> LocalizarTodosAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InsertAsync(Vendedor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamentos).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException )
            {
                throw new IntegridadeException("Não é possível excluir o vendedor(a). O vendedor(a) possui vendas vinculadas ao seu nome!!");
            }
        }

        public async Task UpdateAsync(Vendedor obj)
        {
            bool temAlgum = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);
            if (!temAlgum)
            {
                throw new DllNotFoundException("Id não encontrado!");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }


    }


}
