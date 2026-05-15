using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Taller.CPago
{
    public class Factura
    {
        private IPago ipago;
        private Reparacion reparacion;
        private ulong total;
        private ulong val_reparacion;
        private bool estado = false;
        private Cliente cliente;

        public Factura(Reparacion reparacion, Cliente cliente)
        {
            this.reparacion = reparacion;
            this.cliente = cliente;
            estado = false;
            total = CalcularTotal(reparacion);
            val_reparacion = total;

            // Seleccionar tipo de pago según estado de crédito del cliente
            ipago = cliente.Estado_credito
                ? (IPago)new Con_credito(total, cliente)
                : (IPago)new Contado(total);
        }

        public ulong Total { get => total; }
        public bool Pagada { get => estado; }
        public string TipoPago { get => ipago.GetType().Name; }
        public Cliente Cliente { get => cliente; }
        public Reparacion Reparacion { get => reparacion; }
        public IPago Ipago { get => ipago; }

        public ulong CalcularTotal(Reparacion reparacion)
        {
            return (ulong)reparacion.L_repuestos.Sum(r => (decimal)r.Valor);
        }

        public string ProcesarPago()
        {
            if (estado == true)
                return "⚠ Esta factura ya fue pagada.";

            var resultado = ipago.RealizarPago(total);
            estado = true;

            return resultado;
        }

        public void CambiarMetodoPago(IPago nuevoPago)
        {
            if (estado == true)
                throw new InvalidOperationException("No se puede cambiar el método de pago de una factura ya pagada.");

            ipago = nuevoPago;
        }
    }
}
