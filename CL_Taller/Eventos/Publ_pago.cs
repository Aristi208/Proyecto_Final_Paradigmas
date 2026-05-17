using CL_Taller.CPago;
using System;

namespace CL_Taller.Eventos
{
    public class Publ_cancelacion_pago
    {
        public delegate string dele_cancelacion_pago(Factura factura);

        public event dele_cancelacion_pago evt_cancelacion_pago;

        public string InformarPago(Factura factura)
        {
            if (evt_cancelacion_pago != null)
            {
                return evt_cancelacion_pago.Invoke(factura);
            }

            throw new Exception("No hay eventos suscritos");
        }
    }
}