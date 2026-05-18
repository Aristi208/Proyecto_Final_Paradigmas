using CL_Taller.CPersona;
using Microsoft.AspNetCore.Mvc;

namespace Taller.web.Controllers
{
    public class ClienteController : Controller
    {
        public static List<Cliente> clientes = new();

        public IActionResult Index()
        {
            return View(clientes);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ulong id, string nombre, uint telefono, bool estadoCredito)
        {
            if (clientes.Any(c => c.Id == id))
            {
                TempData["Error"] = $"Ya existe un cliente con el ID {id}";
                return RedirectToAction("Crear");
            }

            var cliente = new Cliente(id, nombre, telefono, estadoCredito);
            clientes.Add(cliente);
            TempData["Exito"] = $"Cliente {nombre} registrado correctamente";
            return RedirectToAction("Index");
        }
    }
}
