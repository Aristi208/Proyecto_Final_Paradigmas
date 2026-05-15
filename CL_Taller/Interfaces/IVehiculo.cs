using CL_Taller.CReparacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.Interfaces
{
    public interface IVehiculo
    {
        abstract string PuestaAPunto();
        abstract string Escaner();
        abstract string DesconexionBateria();
        abstract string CambiarLlantas();
        abstract string CalibrarSensores();
        abstract string CambiarPieza(Repuesto repuesto);


    }
}
