using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.Interfaces;
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

        public abstract override Tuple<string, ulong> CalibrarSensores();

        public abstract override Tuple<string, ulong> CambiarLlantas(); 

        public abstract override Tuple<string, ulong> CambiarPieza(Repuesto repuesto); 

        public abstract override Tuple<string, ulong> DesconexionBateria(); 

        public abstract override Tuple<string, ulong> Escaner(); 

        public abstract override Tuple<string, ulong> PuestaAPunto(); 
    }
}
