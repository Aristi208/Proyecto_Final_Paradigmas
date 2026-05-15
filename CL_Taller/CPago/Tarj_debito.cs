using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPago
{
    public class Tarj_debito : Pago
    {
        public Tarj_debito(ulong monto) : base(monto)
        {
        }

        public override string RealizarPago(ulong monto)
        {
            return $"✔ Pago con tarjeta débito realizado con éxito por ${monto:N0}.";
        }

        public override string ToString()
        {
            return "Tarjeta Débito";
        }
    }
}
