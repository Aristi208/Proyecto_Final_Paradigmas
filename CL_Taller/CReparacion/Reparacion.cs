using CL_Taller.CPersona;
using CL_Taller.CVehiculo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CReparacion
{
    internal class Reparacion
    {
        private Vehiculo vehiculo;
        private DateTime fecha;
        private List<Repuesto> l_repuestos;
        private List<Mecanico> l_mecanicos;
        private bool rep_terminada;

        // TODO: IVehiculos para inyectar tmb se debe meter al constructor y mirar q más se puede meter al constructor
        public Reparacion(Vehiculo vehiculo)
        {
            Vehiculo = vehiculo;
            fecha = DateTime.Now;
            rep_terminada = false;
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
    }
}
