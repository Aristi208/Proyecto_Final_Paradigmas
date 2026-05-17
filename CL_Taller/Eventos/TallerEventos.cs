using CL_Taller.CPago;
using CL_Taller.CReparacion;
using CL_Taller.CVehiculo;

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

        private string OnEntradaVehiculo(Vehiculo vehiculo)
        {
            return $"Vehículo ingresado correctamente -> {vehiculo}";
        }

        private string OnFinalizacionReparacion(Reparacion reparacion)
        {
            return $"Reparación finalizada -> {reparacion}";
        }

        private string OnCancelacionPago(Factura factura)
        {
            return $"Factura pagada correctamente -> {factura}";
        }

        public Publ_entrada PublEntrada
        {
            get => publEntrada;
        }

        public Publ_finalizacion PublFinalizacion
        {
            get => publFinalizacion;
        }

        public Publ_cancelacion_pago PublCancelacion
        {
            get => publCancelacion;
        }
    }
}