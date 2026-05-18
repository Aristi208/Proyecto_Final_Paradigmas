using CL_Taller.CPersona;
using CL_Taller.CVehiculo;
using Taller.web.Controllers;

namespace Taller.web.Datos
{
    public static class DatosPrueba
    {
        public static void Cargar(string rutaBase)
        {
            CargarClientes(Path.Combine(rutaBase, "clientes.txt"));
            CargarMecanicos(Path.Combine(rutaBase, "mecanicos.txt"));
            CargarVehiculos(Path.Combine(rutaBase, "vehiculos.txt"));
        }

        private static void CargarClientes(string ruta)
        {
            foreach (var linea in File.ReadAllLines(ruta))
            {
                var p = linea.Split(',');
                var cliente = new Cliente(ulong.Parse(p[0]), p[1], uint.Parse(p[2]), bool.Parse(p[3]));
                ClienteController.clientes.Add(cliente);
            }
        }

        private static void CargarMecanicos(string ruta)
        {
            foreach (var linea in File.ReadAllLines(ruta))
            {
                var p = linea.Split(',');
                var especialidad = Enum.Parse<RglsPersona.EspecialidadMecanico>(p[3]);
                var mecanico = new Mecanico(ulong.Parse(p[0]), p[1], uint.Parse(p[2]), especialidad);
                MecanicoController.mecanicos.Add(mecanico);
            }
        }

        private static void CargarVehiculos(string ruta)
        {
            foreach (var linea in File.ReadAllLines(ruta))
            {
                var p = linea.Split(',');
                var cliente = ClienteController.clientes.FirstOrDefault(c => c.Id == ulong.Parse(p[4]));
                if (cliente == null) continue;

                Vehiculo vehiculo = p[5] switch
                {
                    "Gasolina" => new Gasolina(p[0], p[1], p[2], ushort.Parse(p[3]), cliente, byte.Parse(p[6])),
                    "Electrico" => new Electrico(p[0], p[1], p[2], ushort.Parse(p[3]), cliente, ushort.Parse(p[6])),
                    "Hibrido" => new Hibrido(p[0], p[1], p[2], ushort.Parse(p[3]), cliente, byte.Parse(p[6])),
                    _ => throw new Exception("Tipo no válido")
                };

                VehiculoController.vehiculos.Add(vehiculo);
            }
        }
    }
}
