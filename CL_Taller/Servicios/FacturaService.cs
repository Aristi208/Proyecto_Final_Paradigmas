using CL_Taller.CPago;
using CL_Taller.CReparacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Taller.Servicios
{
    internal class FacturaService
    {

        private List<Factura> l_facturas = new();

        public List<Factura> L_facturas { get => l_facturas; }

        public void AgregarFactura(Factura factura)
        {
            L_facturas.Add(factura);
        }

        public IEnumerable<Factura> ObtenerTodas()
        {
            return L_facturas;
        }

        public IEnumerable<Factura> BuscarPorCliente(ulong id)
        {
            return L_facturas.Where(f => f.Cliente.Id == id);
        }

        public IEnumerable<Factura> BuscarPorReparacion(ulong id)
        {
            return L_facturas.Where(f => f.Reparacion.Id == id);
        }

        public ulong TotalRecaudado()
        {
            return (ulong)L_facturas.Sum(f => (decimal)f.Total);
        }

        public Dictionary<string, (int cantidad, ulong total)> ResumenPorTipoPago()
        {
            return L_facturas.GroupBy(f => f.Ipago.GetType().Name)
                .ToDictionary(g => g.Key, g => (g.Count(), (ulong)g.Sum(f => (decimal)f.Total)));
        }

        public ulong CalcularTotal(Reparacion rep)
        {
            return new Factura(rep).Total;
        }

        public Factura GenerarFactura(Reparacion reparacion)
        {
            Factura factura = new(reparacion);
            factura.Total = CalcularTotal(reparacion);
            AgregarFactura(factura);
            return factura;
        }

    }
}
