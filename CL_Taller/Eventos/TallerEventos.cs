using CL_Taller.CPago;
using CL_Taller.CVehiculo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.Eventos
{
    public class TallerEventos
    {
        private Publ_entrada publEntrada;
        private Publ_finalizacion publFinalizacion;
        private Publ_cancelacion_pago publCancelacion;

        public TallerEventos()
        {
            publEntrada = new Publ_entrada();
            publFinalizacion = new Publ_finalizacion();
            publCancelacion = new Publ_cancelacion_pago();

            publEntrada.evt_entrada += OnEntradaVehiculo;
            publFinalizacion.evt_finalizacion += OnFinalizacionReparacion;
            publCancelacion.evt_cancelacion_pago += OnCancelacionPago;
        }

        private void OnEntradaVehiculo(Carro carro)
        {
            Console.WriteLine($"[ENTRADA] Se registró ingreso del vehículo: {carro}");
        }

        private void OnFinalizacionReparacion()
        {
            Console.WriteLine($"[FINALIZACIÓN] Una reparación ha sido completada.");
        }

        private void OnCancelacionPago(Factura factura)
        {
            Console.WriteLine($"[PAGO] Se procesó pago de factura: {factura}");
        }

        public Publ_entrada PublEntrada { get => publEntrada; }
        public Publ_finalizacion PublFinalizacion { get => publFinalizacion; }
        public Publ_cancelacion_pago PublCancelacion { get => publCancelacion; }
    }
}
