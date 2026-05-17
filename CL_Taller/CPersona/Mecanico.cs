using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPersona
{
    public class Mecanico : Persona, IValidable
    {
        private RglsPersona.EspecialidadMecanico especialidad;

        public Mecanico(ulong id, string nombre, uint telefono, RglsPersona.EspecialidadMecanico especialidad) : base(id, nombre, telefono)
        {
            this.Especialidad = especialidad;
            Validar();
        }
        public RglsPersona.EspecialidadMecanico Especialidad { get => especialidad; set => especialidad = value; }

        public void Validar()
        {
            Especialidad = especialidad;
        }

        public override string ToString()
        {
            return $"Mecánico: {Nombre} | ID: {Id} | Tel: {Telefono} | Especialidad: {Especialidad}";
        }

    }
}
