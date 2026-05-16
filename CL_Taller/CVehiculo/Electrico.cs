using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    internal class Electrico : Carro
    {
        private ushort autonomia;

        public Electrico(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo, ushort autonomia) : base(placa, marca, modelo, ano, dueno_vehiculo)
        {
            this.Autonomia = autonomia;
        }
        public ushort Autonomia { get => autonomia; 
            set => autonomia = value >= RglsVehiculo.min_autonomia && value <= RglsVehiculo.max_autonomia ?
                value : throw new Exception("Autonomia no valida"); }

        public override string CalibrarSensores()
        {
            return $"Sensores calibrados en Carro Electrico - ${RglsVehiculo.precio_calibrar_Sensores}";
        }

        public override string CambiarLlantas()
        {
            return $"Llantas cambiadas en Carro Electrico - ${RglsVehiculo.precio_cambiar_llantas}";
        }

        public override string CambiarPieza(Repuesto repuesto)
        {
            ulong precio = RglsVehiculo.precio_Cambiar_pieza + repuesto.Valor;
            return $"Pieza cambiada en Carro Electrico {repuesto.Nombre} - ${precio}";
        }

        public override string DesconexionBateria()
        {
            return $"Desconexion de Bateria Carro Electrico - ${RglsVehiculo.precio_Desconexion_bateria}";
        }

        public override string Escaner()
        {
            return $"Escaner realizado en Carro Electrico - ${RglsVehiculo.precio_escaner}";
        }

        public override string PuestaAPunto()
        {
            return $"Puesta a punto en Carro Electrico - ${RglsVehiculo.precio_puesta_A_Punta}";
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Autonomía: {Autonomia}km";
        }
    }
}
