using CRUDMVC.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDMVC.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
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
