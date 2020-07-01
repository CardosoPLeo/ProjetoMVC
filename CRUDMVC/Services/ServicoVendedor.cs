using CRUDMVC.Data;
using CRUDMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamentos).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();

        }


    }


}
