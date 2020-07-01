using CRUDMVC.Models;
using CRUDMVC.Models.ViewModels;
using CRUDMVC.Services;
using CRUDMVC.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace CRUDMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;
        private readonly ServicoDepartamento _servicoDepartamento;

        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento)
        {
            _servicoVendedor = servicoVendedor;
            _servicoDepartamento = servicoDepartamento; 
        }

        public IActionResult Index()
        {
            var lista = _servicoVendedor.LocalizarTodos();
            return View(lista);
        }

        public IActionResult Create()
        {
            var departamentos = _servicoDepartamento.LocalizarTodos();
            var viewModel = new VendedorFormViewModel {Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoVendedor.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null) 
            {
                return NotFound();
            }

            var obj = _servicoVendedor.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoVendedor.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Departamentos> departamentos = _servicoDepartamento.LocalizarTodos();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();

            }

            try
            {
                _servicoVendedor.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                throw new NotFoundException(e.Message);
            }
            catch (DBConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
