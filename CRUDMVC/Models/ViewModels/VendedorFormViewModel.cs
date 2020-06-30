using System.Collections.Generic;
namespace CRUDMVC.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamentos> Departamentos { get; set; }

    }
}
