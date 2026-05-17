using CL_Taller.CPersona;
using CL_Taller.CVehiculo;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CReparacion
{
    public class Reparacion : IValidable
    {
        private ulong id;
        private Vehiculo vehiculo;
        private DateTime fecha;
        private List<Mecanico> l_mecanicos;
        private bool rep_terminada;
        private IVehiculo ivehiculo;
        private List<string> arreglos;
        private ulong valor_total;

        // TODO: IVehiculos para inyectar tmb se debe meter al constructor y mirar q más se puede meter al constructor
        public Reparacion(Vehiculo vehiculo, IVehiculo ivehiculo)
        {
            Vehiculo = vehiculo;
            fecha = DateTime.Now;
            rep_terminada = false;
            Ivehiculo = ivehiculo;
            arreglos = new List<string>();
            l_mecanicos = new List<Mecanico>();
            Valor_total = 0;
            Validar();
        }
         
        public Vehiculo Vehiculo { get => vehiculo; 
            set => vehiculo = value; }
        public DateTime Fecha { get => fecha; }
        public List<Mecanico> L_mecanicos { get => l_mecanicos; 
            set => l_mecanicos = !Rep_terminada ? 
                value : throw new Exception("No se puede añadir mecanicos en una reparacion terminada"); }
        public bool Rep_terminada { get => rep_terminada; set => rep_terminada = !Rep_terminada ? 
                value : throw new Exception("No se puede interferir una reparacion terminada"); }
        public IVehiculo Ivehiculo { get => ivehiculo; set => ivehiculo = value; }
        public List<string> Arreglos { get => arreglos; }
        public ulong Id { get => id; set => id = value; }
        public ulong Valor_total { get => valor_total; set => valor_total = value; }

        public void CalibrarSensores()
        {
            var resultado = ivehiculo.CalibrarSensores();
            arreglos.Add(resultado.Item1);
            Valor_total += resultado.Item2;
        }

        public void CambiarLlantas()
        {
            var resultado = ivehiculo.CambiarLlantas();
            arreglos.Add(resultado.Item1);
            Valor_total += resultado.Item2;
        }

        public void CambiarPieza(Repuesto repuesto)
        {
            var resultado = ivehiculo.CambiarPieza(repuesto);
            arreglos.Add(resultado.Item1);
            Valor_total += resultado.Item2;
        }

        public void DesconexionBateria()
        {
            var resultado = ivehiculo.DesconexionBateria();
            arreglos.Add(resultado.Item1);
            Valor_total += resultado.Item2;
        }

        public void Escaner()
        {
            var resultado = ivehiculo.Escaner();
            arreglos.Add(resultado.Item1);
            Valor_total += resultado.Item2;
        }

        public void PuestaAPunto()
        {
            var resultado = ivehiculo.PuestaAPunto();
            arreglos.Add(resultado.Item1);
            Valor_total += resultado.Item2;
        }

        public void Validar()
        {
            Vehiculo = vehiculo;
            Ivehiculo = ivehiculo;
        }

        public override string ToString()
        {
            string mecanicos = L_mecanicos != null && L_mecanicos.Count > 0
                ? string.Join(", ", L_mecanicos)
                : "Sin mecánicos asignados";

            return $"Reparación | Vehículo: {Vehiculo} | Fecha: {Fecha:dd/MM/yyyy} | " +
                   $"Terminada: {Rep_terminada} | Mecánicos: [{mecanicos}] | " +
                   $"Arreglos: [{string.Join(", ", Arreglos)}]";
        }

    }
}
