using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Taller.web.Models;

namespace Taller.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeleccionarRol(string rol)
        {
            if (string.IsNullOrEmpty(rol))
            {
                HttpContext.Session.Remove("Rol");
                HttpContext.Session.Remove("IdCliente");
                HttpContext.Session.Remove("NombreCliente");
            }
            else
            {
                HttpContext.Session.SetString("Rol", rol);
                HttpContext.Session.Remove("IdCliente");
                HttpContext.Session.Remove("NombreCliente");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
            var mensaje = exceptionFeature?.Error?.Message ?? "Error desconocido";

            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Mensaje = mensaje
            });
        }

        [HttpPost]
        public IActionResult IngresarCliente(ulong idCliente)
        {
            var cliente = ClienteController.clientes.FirstOrDefault(c => c.Id == idCliente);
            if (cliente == null)
                return RedirectToAction("Index");

            HttpContext.Session.SetString("IdCliente", idCliente.ToString());
            HttpContext.Session.SetString("NombreCliente", cliente.Nombre);
            return RedirectToAction("Index");
        }

        public IActionResult CerrarCliente()
        {
            HttpContext.Session.Remove("IdCliente");
            HttpContext.Session.Remove("NombreCliente");
            return RedirectToAction("Index");
        }
    }
}