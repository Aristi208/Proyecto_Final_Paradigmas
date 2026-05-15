using CL_Taller.CPersona;
using CL_Taller.CReparacion;
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

        public abstract override string CalibrarSensores();

        public abstract override string CambiarLlantas(); 

        public abstract override string CambiarPieza(Repuesto repuesto); 

        public abstract override string DesconexionBateria(); 

        public abstract override string Escaner(); 

        public abstract override string PuestaAPunto(); 
    }
}
