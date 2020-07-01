using CRUDMVC.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CRUDMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataAniversario { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double SalarioBase { get; set; }
        public Departamentos Departamentos { get; set; }
        public int DepartamentosId { get; set; }
        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, DateTime dataAniversario, double salarioBase, Departamentos departamentos)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataAniversario = dataAniversario;
            SalarioBase = salarioBase;
            Departamentos = departamentos;
        }


        public void AdcionarVenda(RegistroDeVendas addvenda)
        {
            Vendas.Add(addvenda);
                
        }

        public void RemoverVenda(RegistroDeVendas removevenda)
        {
            Vendas.Remove(removevenda);
        }

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return Vendas.Where(AdcionarVenda => AdcionarVenda.Data >= inicio && AdcionarVenda.Data <= fim).Sum(AdcionarVenda => AdcionarVenda.Quantia);
        }


    }
}
