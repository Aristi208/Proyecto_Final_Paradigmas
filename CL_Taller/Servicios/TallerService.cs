using CL_Taller.CPago;
using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.CVehiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Taller.Servicios
{
    internal class TallerService
    {
        private VehiculoService vehiculoService;
        private ReparacionService reparacionService;
        private FacturaService facturaService;

        public TallerService(VehiculoService vehiculoService,
                            ReparacionService reparacionService,
                            FacturaService facturaService)
        {
            this.vehiculoService = vehiculoService;
            this.reparacionService = reparacionService;
            this.facturaService = facturaService;
        }

        public void AgregarCliente(ulong id, string nombre, uint telefono, bool estCredito)
        {
            new Cliente(id, nombre, telefono, estCredito);
        }

        public void DescontarDeuda(Cliente cliente, ulong monto)
        {
            cliente.Sldo_debe -= monto;
            if (cliente.Sldo_debe < 0)
                cliente.Sldo_debe = 0;
        }

        public bool TerminarReparacion(Carro carro)
        {
            bool terminada = reparacionService.TerminarReparacion(carro);
            if (terminada)
            {
                var rep = reparacionService.BuscarPorVehiculo(carro.Placa).Last();
                facturaService.GenerarFactura(rep);
            }
            return terminada;
        }
    }
}