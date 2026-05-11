using CL_Taller.CPersona;
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
    }
}
