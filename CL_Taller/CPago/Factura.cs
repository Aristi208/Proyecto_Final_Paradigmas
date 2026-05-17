using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.Eventos;
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
            total = reparacion.Valor_total;
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
        public bool Estado { get => estado; }

        public string ProcesarPago(Publ_cancelacion_pago eventoPago)
        {
            if (estado)
                return "⚠ La factura ya fue pagada";

            string resultado = ipago.RealizarPago(total);

            estado = true;

            string evento = eventoPago.InformarPago(this);

            return resultado + "\n" + evento;
        }

        public void CambiarMetodoPago(IPago nuevoPago)
        {
            if (estado == true)
                throw new InvalidOperationException("No se puede cambiar el método de pago de una factura ya pagada.");

            ipago = nuevoPago;
        }

        public override string ToString()
        {
            return $"Factura | Cliente: {Cliente} | Total: ${Total} | " +
                   $"Estado: {Estado} | Reparación: [{Reparacion}]";
        }
    }
}
