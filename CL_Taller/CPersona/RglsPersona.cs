using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPersona
{
    public class RglsPersona
    {
        public static readonly byte valor_nulo = 0;

        // Regex
        public static readonly string regex_id = @"^\d{6,10}$";
        public static readonly string regex_nombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ]{2,}(?:\s[A-Za-zÁÉÍÓÚáéíóúÑñ]{2,})*$";
        public static readonly string regex_telefono = @"^(3\d{9}|\d{7,10})$";

        // Enum
        public enum EspecialidadMecanico
        {
            MecanicoGeneral,
            EspecialistaMotores,
            EspecialistaTransmision,
            EspecialistaCajaAutomatica,
            EspecialistaFrenos,
            EspecialistaSuspension,
            EspecialistaDireccion,
            ElectricistaAutomotriz,
            ElectronicoAutomotriz,
            EspecialistaECU,
            DiagnosticoComputarizado,
            TecnicoInyeccion,
            EspecialistaAireAcondicionado,
            TecnicoRadiadores,
            TecnicoEscape,
            Llantero,
            AlineadorBalanceador,
            Latonero,
            PintorAutomotriz,
            EnderezadorChasis,
            TapiceroAutomotriz,
            InstaladorAudio,
            InstaladorAlarmasGPS,
            TecnicoBaterias,
            TecnicoLuces,
            RestauradorVehicular,
            ModificadorRendimiento,
            TecnicoVehiculosHibridos,
            TecnicoVehiculosElectricos,
        }
    }
}
