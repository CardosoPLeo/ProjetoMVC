using System;
using System.Linq;
using System.Collections.Generic;

namespace CRUDMVC.Models
{
    public class Departamentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamentos()
        {

        }

        public Departamentos(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdcionarVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);

        }

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicio, fim));

        }
    }
}
