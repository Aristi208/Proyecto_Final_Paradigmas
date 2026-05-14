using CL_Taller.CVehiculo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.Eventos
{
    public class Publ_finalizacion
    {

        public delegate void dele_finalizacion();
        public event dele_finalizacion evt_finalizacion;
        public string InformarFinalizacion()
        {
            if (evt_finalizacion != null)
                return $"Se a finalizado el vehiculo";
            else
                throw new Exception("El método se debe llamar desde un evento suscrito");
        }

    }
}
