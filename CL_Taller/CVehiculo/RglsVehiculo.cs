using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    internal class RglsVehiculo
    {
        // Regex
        public static readonly string regex_placa = @"^[A-Z]{3}\d{3}$";
        public static readonly string regex_marca = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ0-9]+(?:[\s-][A-Za-zÁÉÍÓÚáéíóúÑñ0-9]+)*$";
        public static readonly string regex_modelo = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ0-9]+(?:[\s-][A-Za-zÁÉÍÓÚáéíóúÑñ0-9]+)*$";

        // Validadores
        public static readonly ushort ano_min = 1950;
        public static readonly byte ano_max_sum = 2;
        public static readonly ushort min_autonomia = 100;
        public static readonly ushort max_autonomia = 850;
        public static readonly byte min_cant_baterias = 1;
        public static readonly byte max_cant_baterias = 2;
        public static readonly ushort min_cant_cilindros = 2;
        public static readonly ushort max_cant_cilindros = 16;
    }
}
