using CL_Taller.CTaller;
using CL_Taller.Servicios;
using CL_Taller.Eventos;
using CL_Taller.CPersona;

namespace Taller.web
{
    public static class AppState
    {
        public static CL_Taller.CTaller.Taller Taller { get; } = new CL_Taller.CTaller.Taller("Taller Central", new List<Mecanico>());
        public static TallerEventos Eventos { get; } = new TallerEventos();
        public static VehiculoService VehiculoService { get; } = new VehiculoService();
        public static ReparacionService ReparacionService { get; } = new ReparacionService();
        public static FacturaService FacturaService { get; } = new FacturaService();
        public static TallerService TallerService { get; } = new TallerService(
            Taller,
            VehiculoService,
            ReparacionService,
            FacturaService,
            Eventos.PublEntrada,
            Eventos.PublFinalizacion,
            Eventos
        );
    }
}