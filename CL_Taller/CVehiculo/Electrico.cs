using CL_Taller.CPersona;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    internal class Electrico : Carro
    {
        private ushort autonomia;

        public Electrico(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo, ushort autonomia) : base(placa, marca, modelo, ano, dueno_vehiculo)
        {
            this.Autonomia = autonomia;
        }
        public ushort Autonomia { get => autonomia; 
            set => autonomia = value >= RglsVehiculo.min_autonomia && value <= RglsVehiculo.max_autonomia ?
                value : throw new Exception("Autonomia no valida"); }

        public override string CalibrarSensores()
        {
            throw new NotImplementedException();
        }

        public override string CambiarLlantas()
        {
            throw new NotImplementedException();
        }

        public override string CambiarPieza()
        {
            throw new NotImplementedException();
        }

        public override string DesconexionBateria()
        {
            throw new NotImplementedException();
        }

        public override string Escaner()
        {
            throw new NotImplementedException();
        }

        public override string PuestaAPunto()
        {
            throw new NotImplementedException();
        }
    }
}
