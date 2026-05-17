using CL_Taller.CVehiculo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CL_Taller.Servicios
{
    public class VehiculoService
    {

        private List<Vehiculo> l_vehiculos = new();

        public List<Vehiculo> L_vehiculos { get => l_vehiculos; }

        public void Agregar(Vehiculo v)
        {
            L_vehiculos.Add(v);
        }

        public IEnumerable<Vehiculo> ObtenerTodos()
        {
            return L_vehiculos;
        }

        public Vehiculo? BuscarPorPlaca(string placa)
        {
            return L_vehiculos.FirstOrDefault(v => v.Placa == placa);
        }

        public bool Existe(string placa)
        {
            return L_vehiculos.Any(v => v.Placa == placa);
        }

    }
}
