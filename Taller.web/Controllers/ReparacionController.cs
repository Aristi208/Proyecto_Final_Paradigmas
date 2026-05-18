using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.CVehiculo;
using CL_Taller.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Taller.web.Controllers
{
    public class ReparacionController : Controller
    {
        public static List<Reparacion> reparaciones = new();
        private static List<Vehiculo> vehiculos = VehiculoController.vehiculos;
        private static List<Cliente> clientes = ClienteController.clientes;
        private static CL_Taller.Eventos.Publ_finalizacion pubFinalizacion = new();

        static ReparacionController()
        {
            pubFinalizacion.evt_finalizacion += (reparacion) =>
            {
                var cliente = reparacion.Vehiculo.Dueno_vehiculo;
                FacturaController.facturas.Add(new CL_Taller.CPago.Factura(reparacion, cliente));
                return $"Factura generada para {cliente.Nombre}";
            };
        }

        public IActionResult Index()
        {
            return View(reparaciones);
        }

        public IActionResult Crear()
        {
            ViewBag.Vehiculos = vehiculos;
            return View();
        }

        [HttpPost]
        public IActionResult TerminarReparacion(int index)
        {
            var reparacion = reparaciones[index];

            if (reparacion.L_mecanicos == null || reparacion.L_mecanicos.Count == 0)
                throw new Exception("No se puede terminar una reparación sin mecánicos asignados");

            if (reparacion.Arreglos == null || reparacion.Arreglos.Count == 0)
                throw new Exception("No se puede terminar una reparación sin procesos registrados");

            reparacion.Rep_terminada = true;
            pubFinalizacion.InformarFinalizacion(reparacion);
            return RedirectToAction("Index");
        }

        public IActionResult AgregarMecanico(int index)
        {
            ViewBag.Index = index;
            ViewBag.Mecanicos = MecanicoController.mecanicos;
            ViewBag.Reparacion = reparaciones[index];
            return View();
        }

        [HttpPost]
        public IActionResult AgregarMecanicoDetalle(int index, ulong idMecanico)
        {
            var reparacion = reparaciones[index];
            var mecanico = MecanicoController.mecanicos.FirstOrDefault(m => m.Id == idMecanico);
            if (mecanico == null)
                return RedirectToAction("Detalle", new { index });

            if (reparacion.L_mecanicos.Any(m => m.Id == idMecanico))
                throw new Exception("Este mecánico ya está asignado a esta reparación");

            reparacion.L_mecanicos.Add(mecanico);
            return RedirectToAction("Detalle", new { index });
        }
        public IActionResult Detalle(int index)
        {
            ViewBag.Index = index;
            ViewBag.Reparacion = reparaciones[index];
            ViewBag.Mecanicos = MecanicoController.mecanicos;
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProceso(int index, string proceso)
        {
            var reparacion = reparaciones[index];

            if (reparacion.Arreglos.Any(a => a.Contains(proceso)))
                throw new Exception($"El proceso {proceso} ya fue agregado a esta reparación");

            switch (proceso)
            {
                case "Escaner": reparacion.Escaner(); break;
                case "CambiarLlantas": reparacion.CambiarLlantas(); break;
                case "CalibrarSensores": reparacion.CalibrarSensores(); break;
                case "DesconexionBateria": reparacion.DesconexionBateria(); break;
                case "PuestaAPunto": reparacion.PuestaAPunto(); break;
            }
            return RedirectToAction("Detalle", new { index });
        }
        [HttpPost]
        public IActionResult AgregarRepuesto(int index, string nombre, string proveedor, ulong valor)
        {
            var reparacion = reparaciones[index];
            var repuesto = new CL_Taller.CReparacion.Repuesto(nombre, proveedor, DateTime.Now, valor);
            reparacion.L_repuestos.Add(repuesto);
            reparacion.CambiarPieza(repuesto);
            return RedirectToAction("Detalle", new { index });
        }
    }
}
