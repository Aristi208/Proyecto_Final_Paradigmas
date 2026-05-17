using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    public class Electrico : Carro, IValidable
    {
        private ushort autonomia;

        public Electrico(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo, ushort autonomia) : base(placa, marca, modelo, ano, dueno_vehiculo)
        {
            this.Autonomia = autonomia;
            Validar();
        }
        public ushort Autonomia { get => autonomia; 
            set => autonomia = value >= RglsVehiculo.min_autonomia && value <= RglsVehiculo.max_autonomia ?
                value : throw new Exception("Autonomia no valida"); }

        public override Tuple<string, ulong> CalibrarSensores()
        {
            ulong precio = RglsVehiculo.precio_calibrar_Sensores;
            string mensaje = $"Sensores calibrados en Carro Electrico - ${precio}";
            
            return new Tuple<string, ulong> (mensaje, precio);
        }

        public override Tuple<string, ulong> CambiarLlantas()
        {
            ulong precio = RglsVehiculo.precio_cambiar_llantas;
            string mensaje = $"Llantas cambiadas en Carro Electrico - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> CambiarPieza(Repuesto repuesto)
        {
            ulong precio = RglsVehiculo.precio_Cambiar_pieza + repuesto.Valor;
            string mensaje = $"Pieza cambiada en Carro Electrico {repuesto.Nombre} - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> DesconexionBateria()
        {
            ulong precio = RglsVehiculo.precio_Desconexion_bateria;
            string mensaje = $"Desconexion de Bateria Carro Electrico - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> Escaner()
        {
            ulong precio = RglsVehiculo.precio_escaner;
            string mensaje = $"Escaner realizado en Carro Electrico - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> PuestaAPunto()
        {
            ulong precio = RglsVehiculo.precio_puesta_A_Punta;
            string mensaje = $"Puesta a punto en Carro Electrico - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public void Validar()
        {
            Autonomia = autonomia;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Autonomía: {Autonomia}km";
        }
    }
}
