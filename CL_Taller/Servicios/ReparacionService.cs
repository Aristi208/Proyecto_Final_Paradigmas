using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.CVehiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Taller.Servicios
{
    internal class ReparacionService
    {

        private List<Reparacion> l_reparaciones = new();

        public List<Reparacion> L_reparaciones { get => l_reparaciones; }

        public void Agregar(Reparacion reparacion)
        {
            L_reparaciones.Add(reparacion);
        }

        public IEnumerable<Reparacion> ObtenerTodas()
        {
            return L_reparaciones;
        }

        public IEnumerable<Reparacion> BuscarPorVehiculo(string placa)
        {
            return L_reparaciones.Where(r => r.Vehiculo.Placa == placa);
        }

        public IEnumerable<Reparacion> BuscarPorMecanico(ulong id)
        {
            return L_reparaciones.Where(r => r.L_mecanicos.Any(m => m.Id == id));
        }

        public bool TerminarReparacion(Carro carro)
        {
            var reparacion = L_reparaciones.FirstOrDefault(r => r.Vehiculo == carro && !r.Rep_terminada);
            if (reparacion != null)
            {
                reparacion.Rep_terminada = true;
                return true;
            }
            return false;
        }

        public ulong CalcularCostoTotal(Reparacion rep)
        {
            return (ulong)rep.L_repuestos.Sum(r => (decimal)r.Valor);
        }

        public void AgregarRepuesto(Repuesto r)
        {
            L_reparaciones.LastOrDefault()?.L_repuestos.Add(r);
        }
    }
}