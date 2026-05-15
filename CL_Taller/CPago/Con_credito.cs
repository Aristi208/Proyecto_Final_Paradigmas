using CL_Taller.CPersona;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPago
{
    public class Con_credito : Pago
    {
        private Cliente cliente;

        public Con_credito(ulong monto, Cliente cliente) : base(monto)
        {
            this.cliente = cliente;
        }

        public override string RealizarPago(ulong monto)
        {
            cliente.Sldo_debe += monto;
            return $"✔ Pago a crédito registrado. Saldo pendiente: ${monto:N0}.";
        }

        public override string ToString()
        {
            return "Crédito";
        }
    }
}
