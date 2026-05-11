using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CReparacion
{
    internal class RglsReparacion
    {
        // Regex
        public static readonly string regex_nombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ0-9\/\-\s()]+$";
        public static readonly string regex_proveedor = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ0-9.&\-\s]+$";

        // Validadores
        public static readonly sbyte ano_min = -10;
        public static readonly byte valor_nulo = 0;
    }
}
