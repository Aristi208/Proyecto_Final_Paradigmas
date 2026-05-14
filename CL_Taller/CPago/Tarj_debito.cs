using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPago
{
    internal class Tarj_debito : Sin_credito
    {
        public Tarj_debito(ulong monto) : base(monto)
        {
        }

        public override void RealizarPago(ulong monto)
        {
            throw new NotImplementedException();
        }
    }
}
