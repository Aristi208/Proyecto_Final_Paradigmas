using CL_Taller.CPersona;
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
    }
}
