﻿using LoadMeasurementPanel.Web.Models;
using LoadMeasurementPanel.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LoadMeasurementPanel.Web.Controllers
{
    public class PontoMedicaoController : Controller
    {
        private readonly IApiService _apiService;

        public PontoMedicaoController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            if (ModelState.IsValid)
            {
                var chartData = await GerarGraficoDonut();

                return View(chartData);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListaMedidores(string search, int page = 1, int pageSize = 5)
        {
            var listaMedidores = await _apiService.GetAllPoints();
            
            if (listaMedidores.Count == 0 || listaMedidores == null) { return View(); }

            // Pesquisa
            if (!string.IsNullOrEmpty(search))
            {
                listaMedidores = listaMedidores.Where(p => p.Name.Contains(search.ToUpper())).ToList();
            }

            // Paginação
            var totalItems = listaMedidores.Count();
            var medidores = listaMedidores
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
            .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewBag.Search = search;

            return View(medidores);
        }

        [HttpGet()]
        public async Task<IActionResult> DetalhesMedidor(long? id)
        {
            if (id == null) return NotFound();

            var medidor = await _apiService.GetMeasurePointDetailsById(id.Value);

            if (medidor == null) return NotFound();

            return View(medidor);
        }

        [HttpPost]
        public async Task<IActionResult> DesativarMedidor(string name)
        {
            if (name == null) return NotFound();

            var result = await _apiService.DisableMeasurementPointByName(name);

            if(result) return RedirectToAction("ListaMedidores"); ;

            return NotFound();
        }

        private async Task<List<GraficoDonutModel>> GerarGraficoDonut()
        {
            var informations = await _apiService.GetPointsInformations();

            if (informations == null) { return new List<GraficoDonutModel>(); }

            var chartData = new List<GraficoDonutModel>
                {
                    new GraficoDonutModel { Label = "Ativos", Value = informations.NumberActivePoints, Color = "rgba(255, 99, 132, 0.6)" },
                    new GraficoDonutModel { Label = "Inativos", Value = informations.NumberInactivePoints, Color = "rgba(54, 162, 235, 0.6)" }
                };
            ViewBag.TotalMedidores = informations.TotalNumber;
            ViewBag.Ativos = informations.NumberActivePoints;
            ViewBag.Inativos = informations.NumberInactivePoints;

            return chartData;
        }

    }
}
