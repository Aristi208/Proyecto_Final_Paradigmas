using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPago
{
    internal class Contado : Sin_credito
    {
        public Contado(ulong monto) : base(monto)
        {
        }

        public override void RealizarPago(ulong monto)
        {
            throw new NotImplementedException(); // Falta logica
        }
    }
}
