using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc_optimuz.Data;
using mvc_optimuz.Models;

namespace mvc_optimuz.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class PersonalController : Controller
    {
        private readonly OptimuzDbContext _db;

        public PersonalController(OptimuzDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Personal> lista = _db.Personal;
            return View(lista);
        }
        public IActionResult Detalle(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Personal.Find(Id);
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
        public IActionResult Crear(Personal personal)
        {
            if (ModelState.IsValid)
            {
                _db.Personal.Add(personal);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(personal);
        }

        //Get Editar
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Personal.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Personal personal)
        {
            if (ModelState.IsValid)
            {
                _db.Personal.Update(personal);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(personal);
        }

        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Personal.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Personal personal)
        {
            if (personal == null)
            {
                return NotFound();
            }
            _db.Personal.Remove(personal);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
