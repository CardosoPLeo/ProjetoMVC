using CRUDMVC.Models.Enums;
using System;

namespace CRUDMVC.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantia { get; set; }
        public StatusDaVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroDeVendas()
        {

        }

        public RegistroDeVendas(int id, DateTime data, double quantia, StatusDaVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
