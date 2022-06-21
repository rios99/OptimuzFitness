using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc_optimuz.Data;
using mvc_optimuz.Models;
using mvc_optimuz.Models.ViewModels;
using mvc_optimuz.Utilidades;
using System.Security.Claims;

namespace mvc_optimuz.Controllers
{
    [Authorize]
    public class CarroController : Controller
    {

        private readonly OptimuzDbContext _db;
        [BindProperty]
        public ContratoUsuarioVM contratoUsuarioVM { get; set; }

        public CarroController(OptimuzDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<CarroCompra> carroComprasList = new List<CarroCompra>();

            if (HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras)!= null &&
                HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras).Count()>0)
            {
                carroComprasList = HttpContext.Session.Get<List<CarroCompra>>(WC.SessionCarroCompras);
            }

            List<int> promEnCarro = carroComprasList.Select(i => i.PromocionId).ToList();
            IEnumerable<Promocion> promList = _db.Promocion.Where(p => promEnCarro.Contains(p.Id));
            return View(promList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            return RedirectToAction(nameof(Resumen));
        }

        public IActionResult Resumen()
        {
            //Traer usuario logeado
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //----------------------

            List<CarroCompra> carroComprasList = new List<CarroCompra>();

            if (HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras) != null &&
                HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras).Count() > 0)
            {
                carroComprasList = HttpContext.Session.Get<List<CarroCompra>>(WC.SessionCarroCompras);
            }

            List<int> promEnCarro = carroComprasList.Select(i => i.PromocionId).ToList();
            IEnumerable<Promocion> promList = _db.Promocion.Where(p => promEnCarro.Contains(p.Id));

            contratoUsuarioVM = new ContratoUsuarioVM()
            {
                Usuario = _db.Usuario.FirstOrDefault(u => u.Id == claim.Value),
                PromocionLista = promList
            };

            return View(contratoUsuarioVM);

        }

        public IActionResult Remover(int Id)
        {
            List<CarroCompra> carroComprasList = new List<CarroCompra>();

            if (HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras) != null &&
                HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras).Count() > 0)
            {
                carroComprasList = HttpContext.Session.Get<List<CarroCompra>>(WC.SessionCarroCompras);
            }

            carroComprasList.Remove(carroComprasList.FirstOrDefault(p => p.PromocionId == Id));
            HttpContext.Session.Set(WC.SessionCarroCompras, carroComprasList);

            return RedirectToAction(nameof(Index));
        }
    }
}
