using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    public class Hibrido : Carro, IValidable
    {
        private byte cant_baterias;

        public Hibrido(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo, byte cant_baterias) : base(placa, marca, modelo, ano, dueno_vehiculo)
        {
            this.Cant_baterias = cant_baterias;
            Validar();
        }
        public byte Cant_baterias { get => cant_baterias; 
            set => cant_baterias = value >= RglsVehiculo.min_cant_baterias && value <= RglsVehiculo.max_cant_baterias ?
                value : throw new Exception("Cantidad de bateria no valida"); }

        public override Tuple<string, ulong> CalibrarSensores()
        {
            ulong precio = RglsVehiculo.precio_calibrar_Sensores;
            string mensaje = $"Sensores calibrados en Carro Hibrido - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> CambiarLlantas()
        {
            ulong precio = RglsVehiculo.precio_cambiar_llantas;
            string mensaje = $"Llantas cambiadas en Carro Hibrido - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> CambiarPieza(Repuesto repuesto)
        {
            ulong precio = RglsVehiculo.precio_Cambiar_pieza + repuesto.Valor;
            string mensaje = $"Pieza cambiada en Carro Hibrido {repuesto.Nombre} - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> DesconexionBateria()
        {
            ulong precio = RglsVehiculo.precio_Desconexion_bateria;
            string mensaje = $"Desconexion de Bateria Carro Hibrido - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> Escaner()
        {
            ulong precio = RglsVehiculo.precio_escaner;
            string mensaje = $"Escaner realizado en Carro Hibrido - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> PuestaAPunto()
        {
            ulong precio = RglsVehiculo.precio_puesta_A_Punta;
            string mensaje = $"Puesta a punto en Carro Hibrido - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public void Validar()
        {
            Cant_baterias = cant_baterias;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Baterías: {Cant_baterias}";
        }
    }
}
