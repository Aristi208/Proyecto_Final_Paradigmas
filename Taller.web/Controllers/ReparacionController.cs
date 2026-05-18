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

        [HttpPost]
public IActionResult TerminarReparacion(string placa)
        {
            var reparacion = reparaciones.FirstOrDefault(r => r.Vehiculo.Placa == placa && !r.Rep_terminada);
            if (reparacion == null)
            {
                TempData["Error"] = "No se encontró reparación activa para ese vehículo";
                return RedirectToAction("Index");
            }

            if (reparacion.L_mecanicos == null || reparacion.L_mecanicos.Count == 0)
            {
                TempData["Error"] = "No se puede terminar una reparación sin mecánicos asignados";
                return RedirectToAction("Detalle", new { placa });
            }

            if (reparacion.Arreglos == null || reparacion.Arreglos.Count == 0)
            {
                TempData["Error"] = "No se puede terminar una reparación sin procesos registrados";
                return RedirectToAction("Detalle", new { placa });
            }

            reparacion.Rep_terminada = true;
            pubFinalizacion.InformarFinalizacion(reparacion);
            TempData["Exito"] = $"Reparación del vehículo {placa} terminada correctamente";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AgregarMecanicoDetalle(string placa, ulong idMecanico)
        {
            var reparacion = reparaciones.FirstOrDefault(r => r.Vehiculo.Placa == placa && !r.Rep_terminada);
            if (reparacion == null)
                return RedirectToAction("Index");

            var mecanico = MecanicoController.mecanicos.FirstOrDefault(m => m.Id == idMecanico);
            if (mecanico == null)
                return RedirectToAction("Detalle", new { placa });

            if (reparacion.L_mecanicos.Any(m => m.Id == idMecanico))
            {
                TempData["Error"] = "Este mecánico ya está asignado a esta reparación";
                return RedirectToAction("Detalle", new { placa });
            }

            reparacion.L_mecanicos.Add(mecanico);
            TempData["Exito"] = $"Mecánico agregado correctamente";
            return RedirectToAction("Detalle", new { placa });
        }

        public IActionResult Detalle(string placa)
        {
            var reparacion = reparaciones.FirstOrDefault(r => r.Vehiculo.Placa == placa && !r.Rep_terminada);
            if (reparacion == null)
                return RedirectToAction("Index");

            ViewBag.Placa = placa;
            ViewBag.Reparacion = reparacion;
            ViewBag.Mecanicos = MecanicoController.mecanicos;
            ViewBag.Repuestos = AppState.Taller.l_repuestos;
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProceso(string placa, string proceso)
        {
            var reparacion = reparaciones.FirstOrDefault(r => r.Vehiculo.Placa == placa && !r.Rep_terminada);
            if (reparacion == null)
                return RedirectToAction("Index");

            if (reparacion.Arreglos.Any(a => a.Contains(proceso)))
            {
                TempData["Error"] = $"El proceso {proceso} ya fue agregado a esta reparación";
                return RedirectToAction("Detalle", new { placa });
            }

            switch (proceso)
            {
                case "Escaner": reparacion.Escaner(); break;
                case "CambiarLlantas": reparacion.CambiarLlantas(); break;
                case "CalibrarSensores": reparacion.CalibrarSensores(); break;
                case "DesconexionBateria": reparacion.DesconexionBateria(); break;
                case "PuestaAPunto": reparacion.PuestaAPunto(); break;
            }
            TempData["Exito"] = $"Proceso agregado correctamente";
            return RedirectToAction("Detalle", new { placa });
        }

        [HttpPost]
        public IActionResult AgregarRepuesto(string placa, int indexRepuesto)
        {
            var reparacion = reparaciones.FirstOrDefault(r => r.Vehiculo.Placa == placa && !r.Rep_terminada);
            if (reparacion == null)
                return RedirectToAction("Index");

            var repuesto = AppState.Taller.l_repuestos[indexRepuesto];
            reparacion.CambiarPieza(repuesto);
            return RedirectToAction("Detalle", new { placa });
        }
        public IActionResult Crear()
        {
            ViewBag.Vehiculos = VehiculoController.vehiculos;
            return View();
        }

        [HttpPost]
        public IActionResult Crear(string placa)
        {
            var vehiculo = VehiculoController.vehiculos.FirstOrDefault(v => v.Placa == placa);
            if (vehiculo == null)
            {
                TempData["Error"] = "Vehículo no encontrado";
                return RedirectToAction("Crear");
            }

            if (reparaciones.Any(r => r.Vehiculo.Placa == placa && !r.Rep_terminada))
            {
                TempData["Error"] = "Este vehículo ya tiene una reparación activa sin terminar";
                return RedirectToAction("Index");
            }

            if (FacturaController.facturas.Any(f => f.Reparacion.Vehiculo.Placa == placa && !f.Pagada))
            {
                TempData["Error"] = "Este vehículo tiene una factura pendiente de pago";
                return RedirectToAction("Index");
            }

            var reparacion = new CL_Taller.CReparacion.Reparacion(vehiculo, vehiculo);
            reparaciones.Add(reparacion);
            TempData["Exito"] = $"Reparación creada para el vehículo {placa}";
            return RedirectToAction("Index");
        }
    }
}