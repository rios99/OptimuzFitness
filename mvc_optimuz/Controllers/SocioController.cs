using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc_optimuz.Data;
using mvc_optimuz.Models;

namespace mvc_optimuz.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class SocioController : Controller
    {
        private readonly OptimuzDbContext _db;

        public SocioController(OptimuzDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Socio> lista = _db.Socio;
            return View(lista);
        }
        public IActionResult Detalle(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Socio.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Get
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Socio socio)
        {
            if (ModelState.IsValid)
            {
                _db.Socio.Add(socio);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(socio);
        }

        //Get Editar
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Socio.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Socio socio)
        {
            if (ModelState.IsValid)
            {
                _db.Socio.Update(socio);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(socio);
        }

        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Socio.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Socio socio)
        {
            if (socio == null)
            {
                return NotFound();
            }
            _db.Socio.Remove(socio);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

