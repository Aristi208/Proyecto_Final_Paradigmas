using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPersona
{
    internal class Mecanico : Persona
    {
        private RglsPersona.EspecialidadMecanico especialidad;

        public Mecanico(ulong id, string nombre, uint telefono, RglsPersona.EspecialidadMecanico especialidad) : base(id, nombre, telefono)
        {
            this.Especialidad = especialidad;
        }
        internal RglsPersona.EspecialidadMecanico Especialidad { get => especialidad, set => especialidad = value; }

        public override string ToString()
        {
            return $"Mecánico: {Nombre} | ID: {Id} | Tel: {Telefono} | Especialidad: {Especialidad}";
        }
    }
}
