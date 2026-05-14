using CL_Taller.CVehiculo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.Eventos
{
    public class Publ_entrada
    {

        public delegate void dele_entrada(Carro carro);
        public event dele_entrada evt_entrada;

        public string InformarEntradaVehiculo(object vehiculo)
        {
            if (evt_entrada != null && vehiculo is Vehiculo)
                return $"Se a ingresado el vehiculo: {vehiculo.ToString()}";
            else
                throw new Exception("El método se debe llamar desde un evento suscrito");
        }

    }
}
