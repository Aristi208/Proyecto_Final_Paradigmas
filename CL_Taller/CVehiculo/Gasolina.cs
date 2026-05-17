using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    public class Gasolina : Carro, IValidable
    {
        private byte cant_cilindros;

        public Gasolina(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo, byte cant_cilindros) : base(placa, marca, modelo, ano, dueno_vehiculo)
        {
            this.Cant_cilindros = cant_cilindros;
            Validar();
        }
        public byte Cant_cilindros { get => cant_cilindros; 
            set => cant_cilindros = value >= RglsVehiculo.min_cant_cilindros && value <= RglsVehiculo.max_cant_cilindros ?
                value : throw new Exception("Cantidad de cilindros no valida"); }

        public override Tuple<string, ulong> CalibrarSensores()
        {
            ulong precio = RglsVehiculo.precio_calibrar_Sensores;
            string mensaje = $"Sensores calibrados en Carro a Gasolina - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> CambiarLlantas()
        {
            ulong precio = RglsVehiculo.precio_cambiar_llantas;
            string mensaje = $"Llantas cambiadas en Carro a Gasolina - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> CambiarPieza(Repuesto repuesto)
        {
            ulong precio = RglsVehiculo.precio_Cambiar_pieza + repuesto.Valor;
            string mensaje = $"Pieza cambiada en Carro a Gasolina - {repuesto.Nombre} - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> DesconexionBateria()
        {
            ulong precio = RglsVehiculo.precio_Desconexion_bateria;
            string mensaje = $"Desconexion de Bateria Carro a Gasolina - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> Escaner()
        {
            ulong precio = RglsVehiculo.precio_escaner;
            string mensaje = $"Escaner realizado en Carro a Gasolina - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public override Tuple<string, ulong> PuestaAPunto()
        {
            ulong precio = RglsVehiculo.precio_puesta_A_Punta;
            string mensaje = $"Puesta a punto en Carro a Gasolina - ${precio}";

            return new Tuple<string, ulong>(mensaje, precio);
        }

        public void Validar()
        {
            Cant_cilindros = cant_cilindros;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Cilindros: {Cant_cilindros}";
        }
    }
}
