using CL_Taller.CPago;
using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.CVehiculo;
using CL_Taller.Servicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CTaller
{
    public class Taller
    {
        private string nombre;
        public List<Reparacion> l_reparaciones;
        public List<Vehiculo> l_vehiculos_reparaciones;
        public List<Vehiculo> l_vehiculos_listos;
        public List<Factura> l_facturas;
        public List<Cliente> l_clientes;
        public List<Mecanico> l_mecanicos;

        public Taller(string nombre, List<Mecanico> l_mecanicos)
        {
            this.Nombre = nombre;
            l_reparaciones = new List<Reparacion>();
            l_vehiculos_listos = new List<Vehiculo>();
            l_vehiculos_reparaciones = new List <Vehiculo>();
            l_facturas = new List<Factura>();
            l_clientes = new List<Cliente>();
            this.l_mecanicos = new List<Mecanico>();
            this.l_mecanicos = l_mecanicos;
        }

        public string Nombre { get => nombre; set => nombre = value; }

    }
}
