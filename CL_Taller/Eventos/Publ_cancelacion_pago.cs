using CL_Taller.CPago;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.Eventos
{
    public class Publ_cancelacion_pago
    {

        public delegate void dele_cancelacion_pago(Factura factura);
        public event dele_cancelacion_pago evt_cancelacion_pago;

        public string InformarCancelacionPago(Factura factura)  // FALTA IMPLEMENTAR LOS EVENTOS 
        {
            if (evt_cancelacion_pago != null && factura.Estado != false)
                return $"La factura realizada esta en un estado: {factura.Estado}";
            else
                throw new Exception("El método se debe llamar desde un evento suscrito");
        }

    }
}
