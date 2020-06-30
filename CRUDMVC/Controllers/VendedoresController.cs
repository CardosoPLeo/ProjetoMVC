﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC.Models;
using CRUDMVC.Models.ViewModels;
using CRUDMVC.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
