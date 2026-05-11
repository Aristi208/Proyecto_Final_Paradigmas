using CL_Taller.CPersona;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    internal class Carro : Vehiculo
    {
        public Carro(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo) : base(placa, marca, modelo, ano, dueno_vehiculo)
        {
        }
    }
}
