using CL_Taller.CPago;
using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using Microsoft.AspNetCore.Mvc;

namespace Taller.web.Controllers
{
    public class FacturaController : Controller
    {
        public static List<Factura> facturas = new();
        private static CL_Taller.Eventos.Publ_cancelacion_pago eventoPago = new();

        static FacturaController()
        {
            eventoPago.evt_cancelacion_pago += (factura) =>
            {
                Console.WriteLine($"[PAGO] Factura pagada: {factura}");
                return $"Evento disparado para factura de {factura.Cliente.Nombre}";
            };
        }

        public IActionResult Index()
        {
            return View(facturas);
        }

        public IActionResult Pagar(string placa)
        {
            var factura = facturas.LastOrDefault(f => f.Reparacion.Vehiculo.Placa == placa && !f.Pagada);
            if (factura == null)
                return RedirectToAction("Index");
            ViewBag.Placa = placa;
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarPago(string placa, string tipoPago)
        {
            var factura = facturas.LastOrDefault(f => f.Reparacion.Vehiculo.Placa == placa && !f.Pagada);
            if (factura == null)
                return RedirectToAction("Index");

            if (tipoPago == "Credito")
                factura.CambiarMetodoPago(new Con_credito(factura.Total, factura.Cliente));
            else if (tipoPago == "Debito")
                factura.CambiarMetodoPago(new Tarj_debito(factura.Total));
            else
                factura.CambiarMetodoPago(new Contado(factura.Total));

            factura.ProcesarPago(eventoPago);
            return RedirectToAction("Index");
        }

        public IActionResult MisFacturas()
        {
            var idCliente = HttpContext.Session.GetString("IdCliente");
            if (idCliente == null)
                return RedirectToAction("Index", "Home");

            var misFacturas = facturas.Where(f => f.Cliente.Id.ToString() == idCliente).ToList();
            return View(misFacturas);
        }
        public IActionResult Detalle(string placa)
        {
            var factura = facturas.FirstOrDefault(f => f.Reparacion.Vehiculo.Placa == placa);
            if (factura == null)
                return RedirectToAction("Index");
            ViewBag.Factura = factura;
            return View();
        }
    }
}