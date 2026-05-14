using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
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

        public Factura(Reparacion reparacion)
        {
            this.Reparacion = reparacion;
        }

        public IPago Ipago { get => ipago; set => ipago = value; }
        public ulong Total { get => total;
            set => total = value >= RglsFactura.valor_nulo ? value 
                : throw new Exception("Valor total de factura invalido"); }
        public ulong Val_reparacion { get => val_reparacion;
            set => val_reparacion = value >= RglsFactura.valor_nulo ? value 
                : throw new Exception("Valor de la reparacion invalido"); }
        public bool Estado { get => estado; set => estado = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        internal Reparacion Reparacion { get => reparacion; set => reparacion = value; }
    }
}
