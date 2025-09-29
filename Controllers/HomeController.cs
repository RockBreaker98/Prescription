using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prescription.Models;
using PrescriptionApp.Models;

namespace Prescription.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PrescriptionContext? _context;

    public HomeController(ILogger<HomeController> logger, PrescriptionContext ctx)
    {
        _logger = logger;
        _context = ctx;
    }

    // Show all prescriptions in table
    public IActionResult Index()
    {
        if (_context == null)
        {
            // Handle the case where context is null, e.g., return an empty list or an error view
            return View(new List<PrescriptionModel>());
        }

        var prescriptions = _context.Prescriptions
            .OrderBy(p => p.MedicationName)
            .ToList();

        return View(prescriptions);
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
