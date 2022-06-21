using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc_optimuz.Data;
using mvc_optimuz.Models;

namespace mvc_optimuz.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class ContratoController : Controller
    {
        private readonly OptimuzDbContext _db;

        public ContratoController(OptimuzDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Contrato> lista = _db.Contrato;
            return View(lista);
        }

        //Get
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _db.Contrato.Add(contrato);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
           return View(contrato);
        }

        //Get Editar
        public IActionResult Editar(int? Id)
        {
            if (Id==null || Id==0)
            {
                return NotFound();
            }
            var obj = _db.Contrato.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _db.Contrato.Update(contrato);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Contrato.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Contrato contrato)
        {
            if (contrato == null)
            {
                return NotFound();
            }
            _db.Contrato.Remove(contrato);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
