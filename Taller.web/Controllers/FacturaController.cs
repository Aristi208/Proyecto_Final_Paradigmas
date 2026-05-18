using CL_Taller.CPago;
using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using Microsoft.AspNetCore.Mvc;

namespace Taller.web.Controllers
{
    public class FacturaController : Controller
    {
        public static List<Factura> facturas = new();
        private static List<Reparacion> reparaciones = ReparacionController.reparaciones;
        private static List<Cliente> clientes = ClienteController.clientes;
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

        public IActionResult Crear()
        {
            ViewBag.Reparaciones = reparaciones;
            ViewBag.Clientes = clientes;
            return View();
        }

        [HttpPost]
        public IActionResult Crear(int indexReparacion, ulong idCliente)
        {
            var reparacion = reparaciones[indexReparacion];
            var cliente = clientes.FirstOrDefault(c => c.Id == idCliente);
            if (cliente == null)
                return RedirectToAction("Crear");

            var factura = new Factura(reparacion, cliente);
            facturas.Add(factura);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ProcesarPago(int index, string tipoPago)
        {
            var factura = facturas[index];

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
        public IActionResult Pagar(int index)
        {
            ViewBag.Index = index;
            return View();
        }
    }
}
