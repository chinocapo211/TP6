using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6.Models;

namespace TP6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.listaPartidos = BD.listarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int IdPartido)
    {
        ViewBag.infoPartido = BD.verInfoPartido(IdPartido);
        ViewBag.listarCandidatos = BD.listarCandidatos(IdPartido);
        return View();
    }
    public IActionResult VerDetalleCandidato(int IdCandidato)
    {
        ViewBag.infoCandidato = BD.verInfoCandidato(IdCandidato);
        return View();
    }
    public IActionResult AgregarCandidato(int IdPartido)
    {
        ViewBag.idPartido = IdPartido;
        ViewBag.infoPartido = BD.verInfoPartido(IdPartido);
        return View();
    }
     [HttpPost]
    public IActionResult GuardarCandidato(Candidatos can)
    {
        BD.AgregarCandidato(can);
        return RedirectToAction("VerDetallePartido",new {IdPartido= can.IdPartido});
    }
    public IActionResult EliminarCandidato(int IdCandidato, int IdPartido)
    {
        BD.EliminarCantidato(IdCandidato);
        return RedirectToAction("VerDetallePartido",new {IdPartido= IdPartido});
    }
    public IActionResult Elecciones()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
