using CL_Taller.CReparacion;
using System;

namespace CL_Taller.Eventos
{
    public class Publ_finalizacion
    {
        public delegate string dele_finalizacion(Reparacion reparacion);

        public event dele_finalizacion evt_finalizacion;

        public string InformarFinalizacion(Reparacion reparacion)
        {
            if (evt_finalizacion != null)
            {
                return evt_finalizacion.Invoke(reparacion);
            }

            throw new Exception("No hay eventos suscritos");
        }
    }
}