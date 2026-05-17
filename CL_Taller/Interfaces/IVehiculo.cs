using CL_Taller.CReparacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.Interfaces
{
    public interface IVehiculo
    {
        abstract Tuple<string, ulong> PuestaAPunto();
        abstract Tuple<string, ulong> Escaner();
        abstract Tuple<string, ulong> DesconexionBateria();
        abstract Tuple<string, ulong> CambiarLlantas();
        abstract Tuple<string, ulong> CalibrarSensores();
        abstract Tuple<string, ulong> CambiarPieza(Repuesto repuesto);


    }
}
