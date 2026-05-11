using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPersona
{
    internal class Mecanico : Persona
    {
        public Mecanico(ulong id, string nombre, uint telefono, RglsPersona.EspecialidadMecanico especialidad) : base(id, nombre, telefono)
        {
        }
    }
}
