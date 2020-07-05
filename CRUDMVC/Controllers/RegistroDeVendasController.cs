﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMVC.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly ServicoRegistroDeVendas _servicoRegistroDeVendas;

        public RegistroDeVendasController(ServicoRegistroDeVendas servicoRegistroDeVendas)
        {
            _servicoRegistroDeVendas = servicoRegistroDeVendas;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> BuscaSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var resultado = await _servicoRegistroDeVendas.BuscaPorDataAsync(minDate, maxDate);
            return View(resultado);
        }

        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}
