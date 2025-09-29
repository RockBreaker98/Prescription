using Microsoft.AspNetCore.Mvc;
using PrescriptionApp.Models;

namespace PrescriptionApp.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly PrescriptionContext _context;

        public PrescriptionController(PrescriptionContext ctx)
        {
            _context = ctx;
        }

        // GET: Add
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Statuses = new[] { "New", "Filled", "Pending" };

            return View("Edit", new PrescriptionModel
            {
                FillStatus = "New",
                RequestTime = DateTime.Now
            });
        }

        // POST: Add
        [HttpPost]
        public IActionResult Add(PrescriptionModel prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Prescriptions.Add(prescription);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Edit", prescription);
        }

        // GET: Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prescription = _context.Prescriptions.Find(id);
            if (prescription == null) return NotFound();

            ViewBag.Action = "Edit";
            ViewBag.Statuses = new[] { "New", "Filled", "Pending" };

            return View(prescription);
        }

        // POST: Edit
        [HttpPost]
        public IActionResult Edit(PrescriptionModel prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Prescriptions.Update(prescription);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(prescription);
        }

        // GET: Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prescription = _context.Prescriptions.Find(id);
            if (prescription == null) return NotFound();

            return View(prescription);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var prescription = _context.Prescriptions.Find(id);
            if (prescription == null) return NotFound();

            _context.Prescriptions.Remove(prescription);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        
        // GET: Index
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
