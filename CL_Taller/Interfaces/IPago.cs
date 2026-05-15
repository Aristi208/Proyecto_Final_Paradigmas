using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.Interfaces
{
    public interface IPago
    {
        string RealizarPago(ulong monto);
    }
}
