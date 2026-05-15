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

        protected ulong Monto { get => monto;
            set => monto = value >= RglsFactura.valor_nulo ? value :
                throw new Exception($"Valor del monto invalida, tiene que ser mayor a: {RglsFactura.valor_nulo}"); }

        public abstract string RealizarPago(ulong monto);

        public abstract override string ToString();
    }
}