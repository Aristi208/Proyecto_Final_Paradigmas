using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPago
{
    internal class Con_credito : Pago
    {
        public Con_credito(ulong monto) : base(monto)
        {
        }

        public override void RealizarPago(ulong monto)
        {
            // Falta logica
        }
    }
}
