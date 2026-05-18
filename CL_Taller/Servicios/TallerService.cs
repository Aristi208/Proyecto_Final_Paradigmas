using CL_Taller.CPago;
using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.CVehiculo;
using CL_Taller.CTaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL_Taller.Eventos;

namespace CL_Taller.Servicios
{
    public class TallerService
    {
        public Taller taller;
        public Publ_entrada publ_Entrada;
        public Publ_finalizacion publ_Finalizacion;
        public TallerEventos eventos;
        private VehiculoService vehiculoService;
        private ReparacionService reparacionService;
        private FacturaService facturaService;

        public TallerService(
            Taller taller,
            VehiculoService vehiculoService,
            ReparacionService reparacionService,
            FacturaService facturaService,
            Publ_entrada publEntrada,
            Publ_finalizacion publFinalizacion,
            TallerEventos eventos)
        {
            this.taller = taller;
            this.vehiculoService = vehiculoService;
            this.reparacionService = reparacionService;
            this.facturaService = facturaService;

            this.publ_Entrada = publEntrada;
            this.publ_Finalizacion = publFinalizacion;
            this.eventos = eventos;
        }

        public void AgregarRepuesto(string nombre, string proveedor, DateTime fecha_compra, ulong valor)
        {
            taller.l_repuestos.Add(new Repuesto(nombre, proveedor, fecha_compra, valor));
        }

        public void AgregarCliente(ulong id, string nombre, uint telefono, bool estCredito)
        {
            taller.l_clientes.Add(new Cliente(id, nombre, telefono, estCredito));
        }

        public void Añadir_vehiculo_gas(string placa, string marca, string modelo, ushort ano, Cliente dueno, byte cant_cilindros)
        {
            taller.l_vehiculos_reparaciones.Add(new Gasolina(placa, marca, modelo, ano, dueno, cant_cilindros));
        }
        public void Añadir_vehiculo_electrico(string placa, string marca, string modelo, ushort ano, Cliente dueno, ushort autonomia)
        {
            taller.l_vehiculos_reparaciones.Add(new Electrico(placa, marca, modelo, ano, dueno, autonomia));
        }
        public void Añadir_vehiculo_hibrido(string placa, string marca, string modelo, ushort ano, Cliente dueno, byte cant_baterias)
        {
            taller.l_vehiculos_reparaciones.Add(new Hibrido(placa, marca, modelo, ano, dueno, cant_baterias));
        }

        public string IngresarVehiculo(Vehiculo vehiculo)
        {
            taller.l_vehiculos_reparaciones.Add(vehiculo);

            Reparacion rep = new Reparacion(vehiculo, vehiculo);

            reparacionService.Agregar(rep);

            taller.l_reparaciones.Add(rep);

            return eventos.PublEntrada.InformarEntradaVehiculo(vehiculo);
        }

        public void DescontarDeuda(Cliente cliente, ulong monto)
        {
            cliente.Sldo_debe -= monto;
            if (cliente.Sldo_debe < 0)
                cliente.Sldo_debe = 0;
        }

        public string TerminarReparacion(Carro carro)
        {
            bool terminada = reparacionService.TerminarReparacion(carro);

            if (!terminada)
                return "No se encontró reparación activa";

            Reparacion rep = reparacionService
                .BuscarPorVehiculo(carro.Placa)
                .Last();

            Factura factura = facturaService
                .GenerarFactura(rep, carro.Dueno_vehiculo);

            string mensajeEvento =
                eventos.PublFinalizacion.InformarFinalizacion(rep);

            return mensajeEvento +
                   $"\nFactura generada -> ${factura.Total}";
        }
    }
}
