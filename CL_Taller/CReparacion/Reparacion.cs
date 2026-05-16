using CL_Taller.CPersona;
using CL_Taller.CVehiculo;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CReparacion
{
    public class Reparacion
    {
        private ulong id;
        private Vehiculo vehiculo;
        private DateTime fecha;
        private List<Repuesto> l_repuestos;
        private List<Mecanico> l_mecanicos;
        private bool rep_terminada;
        private IVehiculo ivehiculo;
        private List<string> arreglos;

        // TODO: IVehiculos para inyectar tmb se debe meter al constructor y mirar q más se puede meter al constructor
        public Reparacion(Vehiculo vehiculo, IVehiculo ivehiculo)
        {
            Vehiculo = vehiculo;
            fecha = DateTime.Now;
            rep_terminada = false;
            Ivehiculo = ivehiculo;
            arreglos = new List<string>();
            l_repuestos = new List<Repuesto>();
            l_mecanicos = new List<Mecanico>();
        }
         
        internal Vehiculo Vehiculo { get => vehiculo; 
            set => vehiculo = value; }
        public DateTime Fecha { get => fecha; }
        internal List<Repuesto> L_repuestos { get => l_repuestos; 
            set => l_repuestos =  !Rep_terminada ? 
                value : throw new Exception("No se puede añadir repuesto en una reparacion terminada"); }
        internal List<Mecanico> L_mecanicos { get => l_mecanicos; 
            set => l_mecanicos = !Rep_terminada ? 
                value : throw new Exception("No se puede añadir mecanicos en una reparacion terminada"); }
        public bool Rep_terminada { get => rep_terminada; set => rep_terminada = !Rep_terminada ? 
                value : throw new Exception("No se puede interferir una reparacion terminada"); }
        public IVehiculo Ivehiculo { get => ivehiculo; set => ivehiculo = value; }
        public List<string> Arreglos { get => arreglos; }
        public ulong Id { get => id; set => id = value; }

        public void CalibrarSensores()
        {
            arreglos.Add(ivehiculo.CalibrarSensores());
        }

        public void CambiarLlantas()
        {
            arreglos.Add(ivehiculo.CambiarLlantas());
        }

        public void CambiarPieza(Repuesto repuesto)
        {
            arreglos.Add(ivehiculo.CambiarPieza(repuesto));
        }

        public void DesconexionBateria()
        {
            arreglos.Add(ivehiculo.DesconexionBateria());
        }

        public void Escaner()
        {
            arreglos.Add(ivehiculo.Escaner());
        }

        public void PuestaAPunto()
        {
            arreglos.Add(ivehiculo.PuestaAPunto());
        }

        public override string ToString()
        {
            string mecanicos = L_mecanicos != null && L_mecanicos.Count > 0
                ? string.Join(", ", L_mecanicos)
                : "Sin mecánicos asignados";

            string repuestos = L_repuestos != null && L_repuestos.Count > 0
                ? string.Join(", ", L_repuestos)
                : "Sin repuestos";

            return $"Reparación | Vehículo: {Vehiculo} | Fecha: {Fecha:dd/MM/yyyy} | " +
                   $"Terminada: {Rep_terminada} | Mecánicos: [{mecanicos}] | " +
                   $"Repuestos: [{repuestos}] | Arreglos: [{string.Join(", ", Arreglos)}]";
        }

    }
}
