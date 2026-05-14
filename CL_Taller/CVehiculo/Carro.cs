using CL_Taller.CPersona;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    public abstract class Carro : Vehiculo
    {
        public Carro(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo) 
            : base(placa, marca, modelo, ano, dueno_vehiculo)
        {
        }

        public abstract override string CalibrarSensores(); // Falta logica - mensaje

        public abstract override string CambiarLlantas(); // Falta logica - mensaje

        public abstract override string CambiarPieza(); // Falta logica - mensaje

        public abstract override string DesconexionBateria(); // Falta logica - mensaje

        public abstract override string Escaner(); // Falta logica - mensaje

        public abstract override string PuestaAPunto(); // Falta logica - mensaje
    }
}
