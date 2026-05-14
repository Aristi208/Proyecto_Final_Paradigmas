using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.Interfaces
{
    public interface IAutenticable
    {
        bool Autenticar(string usuario, string clave);

        void CerrarSesion();

        string ObtenerRol();

    }
}
