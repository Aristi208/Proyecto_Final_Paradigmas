using CL_Taller.CVehiculo;
using CL_Taller.CPersona;
using Microsoft.AspNetCore.Mvc;

namespace Taller.web.Controllers
{
    public class VehiculoController : Controller
    {
        public static List<Vehiculo> vehiculos = new();

        public IActionResult Index()
        {
            return View(vehiculos);
        }

        public IActionResult Crear()
        {
            ViewBag.Clientes = ClienteController.clientes;
            return View();
        }

        [HttpPost]
        public IActionResult Crear(string placa, string marca, string modelo, ushort ano,
            string tipo, byte cilindros, ushort autonomia, byte baterias, ulong idCliente)
        {
            if (vehiculos.Any(v => v.Placa == placa))
            {
                TempData["Error"] = $"Ya existe un vehículo con la placa {placa}";
                return RedirectToAction("Crear");
            }

            var cliente = ClienteController.clientes.FirstOrDefault(c => c.Id == idCliente);
            if (cliente == null)
                return RedirectToAction("Crear");

            Vehiculo vehiculo = tipo switch
            {
                "Gasolina" => new Gasolina(placa, marca, modelo, ano, cliente, cilindros),
                "Electrico" => new Electrico(placa, marca, modelo, ano, cliente, autonomia),
                "Hibrido" => new Hibrido(placa, marca, modelo, ano, cliente, baterias),
                _ => throw new Exception("Tipo de vehículo no válido")
            };

            vehiculos.Add(vehiculo);
            var reparacion = new CL_Taller.CReparacion.Reparacion(vehiculo, vehiculo);
            ReparacionController.reparaciones.Add(reparacion);

            return RedirectToAction("Index");
        }
        public IActionResult MisVehiculos()
        {
            var idCliente = HttpContext.Session.GetString("IdCliente");
            if (idCliente == null)
                return RedirectToAction("Index", "Home");

            var misVehiculos = vehiculos.Where(v => v.Dueno_vehiculo.Id.ToString() == idCliente).ToList();
            return View(misVehiculos);
        }
    }
}