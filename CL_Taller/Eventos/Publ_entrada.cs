using CL_Taller.CVehiculo;
using System;

namespace CL_Taller.Eventos
{
    public class Publ_entrada
    {
        public delegate string dele_entrada(Vehiculo vehiculo);

        public event dele_entrada evt_entrada;

        public string InformarEntradaVehiculo(Vehiculo vehiculo)
        {
            if (evt_entrada != null)
            {
                return evt_entrada.Invoke(vehiculo);
            }

            throw new Exception("No hay eventos suscritos");
        }
    }
}