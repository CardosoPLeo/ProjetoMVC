using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDMVC.Models;

namespace CRUDMVC.Data
{
    public class CRUDMVCContext : DbContext
    {
        public CRUDMVCContext (DbContextOptions<CRUDMVCContext> options)
            : base(options)
        {
        }

        public DbSet<CRUDMVC.Models.Departamentos> Departamentos { get; set; }
    }
}
