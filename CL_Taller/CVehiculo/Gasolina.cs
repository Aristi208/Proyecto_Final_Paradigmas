using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    internal class Gasolina : Carro
    {
        private byte cant_cilindros;

        public Gasolina(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo, byte cant_cilindros) : base(placa, marca, modelo, ano, dueno_vehiculo)
        {
            this.Cant_cilindros = cant_cilindros;
        }
        public byte Cant_cilindros { get => cant_cilindros; 
            set => cant_cilindros = value >= RglsVehiculo.min_cant_cilindros && value <= RglsVehiculo.max_cant_cilindros ?
                value : throw new Exception("Cantidad de cilindros no valida"); }

        public override string CalibrarSensores()
        {
            return $"Sensores calibrados en Carro a Gasolina - ${RglsVehiculo.precio_calibrar_Sensores}";
        }

        public override string CambiarLlantas()
        {
            return $"Llantas cambiadas en Carro a Gasolina - ${RglsVehiculo.precio_cambiar_llantas}";
        }

        public override string CambiarPieza(Repuesto repuesto)
        {
            ulong precio = RglsVehiculo.precio_Cambiar_pieza + repuesto.Valor;
            return $"Pieza cambiada en Carro a Gasolina {repuesto.Nombre} - ${precio}";
        }

        public override string DesconexionBateria()
        {
            return $"Desconexion de Bateria Carro a Gasolina - ${RglsVehiculo.precio_Desconexion_bateria}";
        }

        public override string Escaner()
        {
            return $"Escaner realizado en Carro a Gasolina - ${RglsVehiculo.precio_escaner}";
        }

        public override string PuestaAPunto()
        {
            return $"Puesta a punto en Carro a Gasolina - ${RglsVehiculo.precio_puesta_A_Punta}";
        }
    }
}
