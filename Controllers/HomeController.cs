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
        ViewBag.Partidos = BD.ListarPartidos();
        return View("Index");
    }

    public IActionResult VerDetallePartido(int idPartido){
        ViewBag.Partido = BD.VerInfoPartido(idPartido);
        ViewBag.Candidatos = BD.ListarCandidatos(idPartido);
        return View("VerDetallePartido");
    }

    public IActionResult VerDetalleCandidato(int idCandidato){
        ViewBag.Candidato = BD.VerInfoCandidato(idCandidato);
        return View("VerDetalleCandidato");
    }

    public IActionResult AgregarCandidato(int idPartido){
        ViewBag.Partido = BD.VerInfoPartido(idPartido);
        return View("AgregarCandidato");
    }

    public IActionResult GuardarCandidato(Candidatos can){
        ViewBag.Partido = BD.VerInfoPartido(can.idPartido);
        ViewBag.Candidatos = BD.ListarCandidatos(can.idPartido);
        //Candidatos can = new Candidatos{idC,idP,ape,nom,nac,fot,pos};
        AgregarCandidato(can);
        return View("AgregarCandidato");
    }

    public IActionResult EliminarCandidato(int idCandidato, int idPartido){
        ViewBag.Partido = BD.VerInfoPartido(idPartido);
        ViewBag.Candidatos = BD.ListarCandidatos(idPartido);
        EliminarCandidato(idCandidato);
        return View("VerDetallePartido");
    }

    public IActionResult Elecciones(){
        return View("Elecciones");
    }

    public IActionResult Creditos(){
        return View("Creditos");
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
