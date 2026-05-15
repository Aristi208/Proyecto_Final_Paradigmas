using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPago
{
    public class Contado : Pago
    {
        public Contado(ulong monto) : base(monto)
        {
        }

        public override string RealizarPago(ulong monto)
        {
            return $"✔ Pago de contado realizado con éxito por ${monto:N0}.";
        }

        public override string ToString()
        {
            return "Contado";
        }
    }
}
