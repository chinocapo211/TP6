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
    public IActionResult VerDetallePartido(int idPartido)
    {
        ViewBag.infoPartido = BD.verInfoPartido(idPartido);
        ViewBag.listarCandidatos = BD.listarCandidatos(idPartido);
        return View();
    }
    public IActionResult VerDetalleCandidato(int idCandidato)
    {
        ViewBag.infoCandidato = BD.verInfoCandidato(idCandidato);
        return View();
    }
    public IActionResult AgregarCandidato(int idPartido)
    {
        ViewBag.idPartido = idPartido;
        return View();
    }
     [HttpPost]
    public IActionResult GuardarCandidato(Candidatos can)
    {
        BD.agregarCandidato(can);
        return RedirectToAction("VerDetallePartido",new {idPartido= can.idPartido});
    }
    public IActionResult EliminarCandidato(int idCandidato, int idPartido)
    {
        BD.EliminarCantidato(idCandidato);
        return RedirectToAction("VerDetallePartido",new {idPartido= idPartido});
    }
    public IActionResult elecciones()
    {
        return View();
    }
    public IActionResult creditos()
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
