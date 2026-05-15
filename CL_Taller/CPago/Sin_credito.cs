using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPago
{
    public abstract class Sin_credito : Pago
    {
        public Sin_credito(ulong monto) : base(monto)
        {
        }

        public abstract override string RealizarPago(ulong monto); //Falta logica en las derivadas

        public abstract override string ToString();
    }
}
