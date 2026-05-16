using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    internal class Hibrido : Carro
    {
        private byte cant_baterias;

        public Hibrido(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo, byte cant_baterias) : base(placa, marca, modelo, ano, dueno_vehiculo)
        {
            this.Cant_baterias = cant_baterias;
        }
        public byte Cant_baterias { get => cant_baterias; 
            set => cant_baterias = value >= RglsVehiculo.min_cant_baterias && value <= RglsVehiculo.max_cant_baterias ?
                value : throw new Exception("Cantidad de bateria no valida"); }

        public override string CalibrarSensores()
        {
            return $"Sensores calibrados en Carro Hibrido - ${RglsVehiculo.precio_calibrar_Sensores}";
        }

        public override string CambiarLlantas()
        {
            return $"Llantas cambiadas en Carro Hibrido - ${RglsVehiculo.precio_cambiar_llantas}";
        }

        public override string CambiarPieza(Repuesto repuesto)
        {
            ulong precio = RglsVehiculo.precio_Cambiar_pieza + repuesto.Valor;
            return $"Pieza cambiada en Carro Hibrido {repuesto.Nombre} - ${precio}";
        }

        public override string DesconexionBateria()
        {
            return $"Desconexion de Bateria Carro Hibrido - ${RglsVehiculo.precio_Desconexion_bateria}";
        }

        public override string Escaner()
        {
            return $"Escaner realizado en Carro Hibrido - ${RglsVehiculo.precio_escaner}";
        }

        public override string PuestaAPunto()
        {
            return $"Puesta a punto en Carro Hibrido - ${RglsVehiculo.precio_puesta_A_Punta}";
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Baterías: {Cant_baterias}";
        }
    }
}
