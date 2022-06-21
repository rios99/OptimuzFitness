using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc_optimuz.Data;
using mvc_optimuz.Models;
using mvc_optimuz.Models.ViewModels;

namespace mvc_optimuz.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class PromocionController : Controller
    {
        private readonly OptimuzDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PromocionController(OptimuzDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Promocion> lista = _db.Promocion.Include(c=>c.Contrato);
            return View(lista);
        }

        //Get
        public IActionResult Upsert(int? Id)
        {
            //IEnumerable<SelectListItem> contratoDropDown = _db.Contrato.Select(c => new SelectListItem
            //{
            //    Text = c.NombreContrato,
            //    Value = c.Id.ToString()
            //});

            //ViewBag.contratoDropDown = contratoDropDown;

            //Promocion promocion = new Promocion();

            PromocionVM promocionVM = new PromocionVM()
            {
                Promocion = new Promocion(),
                ContratoLista = _db.Contrato.Select(c => new SelectListItem
                {
                    Text = c.NombreContrato,
                    Value = c.Id.ToString()
                })
            };

            if (Id == null)
            {
                //Crear nueva promocion
                return View(promocionVM);
            }
            else
            {
                promocionVM.Promocion = _db.Promocion.Find(Id);
                if (promocionVM.Promocion == null)
                {
                    return NotFound();
                }
                return View(promocionVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PromocionVM promocionVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                if (promocionVM.Promocion.Id == 0)
                {
                    //Crear
                    string upload = webRootPath + WC.ImagenRuta;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName+extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    promocionVM.Promocion.ImagenURL = fileName + extension;
                    _db.Promocion.Add(promocionVM.Promocion);
                }
                else
                {
                    //Actualizar
                    var objPromocion = _db.Promocion.AsNoTracking().FirstOrDefault(p => p.Id == promocionVM.Promocion.Id);

                    if (files.Count > 0)
                    {
                        string upload = webRootPath + WC.ImagenRuta;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        //borra img anterior
                        var anteriorFile = Path.Combine(upload, objPromocion.ImagenURL);
                        if (System.IO.File.Exists(anteriorFile))
                        {
                            System.IO.File.Delete(anteriorFile);
                        }
                        //--------------------------

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        promocionVM.Promocion.ImagenURL = fileName + extension;
                    }
                    else
                    {
                        promocionVM.Promocion.ImagenURL = objPromocion.ImagenURL;
                    }
                    _db.Promocion.Update(promocionVM.Promocion);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promocionVM);
        }

        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id==null || Id==0)
            {
                return NotFound();
            }

            Promocion promocion = _db.Promocion.Include(c => c.Contrato).FirstOrDefault(p=>p.Id==Id);

            if (promocion == null)
            {
                return NotFound();

            }
            return View(promocion);
        }

        //Post Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Promocion promocion)
        {
            if (promocion == null)
            {
                return NotFound();
            }

            string upload = _webHostEnvironment.WebRootPath + WC.ImagenRuta;

            //borra img anterior
            var anteriorFile = Path.Combine(upload, promocion.ImagenURL);
            if (System.IO.File.Exists(anteriorFile))
            {
                System.IO.File.Delete(anteriorFile);
            }
            //--------------------------

            _db.Promocion.Remove(promocion);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
