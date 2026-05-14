using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPago
{
    public abstract class Pago : IPago
    {

        private ulong monto;

        public Pago(ulong monto)
        {
            this.Monto = monto;
        }

        public ulong Monto { get => monto; set => monto = value; }

        public abstract void RealizarPago(ulong monto);

    }
}
