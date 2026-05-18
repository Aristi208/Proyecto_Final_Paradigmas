using CL_Taller.CPersona;
using Microsoft.AspNetCore.Mvc;

namespace Taller.web.Controllers
{
    public class MecanicoController : Controller
    {
        public static List<Mecanico> mecanicos = new();

        public IActionResult Index()
        {
            return View(mecanicos);
        }

        public IActionResult Crear()
        {
            ViewBag.Especialidades = Enum.GetValues(typeof(RglsPersona.EspecialidadMecanico));
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ulong id, string nombre, uint telefono, RglsPersona.EspecialidadMecanico especialidad)
        {
            if (mecanicos.Any(m => m.Id == id))
            {
                TempData["Error"] = $"Ya existe un mecánico con el ID {id}";
                return RedirectToAction("Crear");
            }

            var mecanico = new Mecanico(id, nombre, telefono, especialidad);
            mecanicos.Add(mecanico);
            TempData["Exito"] = $"Mecánico {nombre} registrado correctamente";
            return RedirectToAction("Index");
        }
    }
}