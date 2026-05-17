using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CPersona
{
    public class Cliente : Persona, IValidable
    {
        private bool estado_credito;
        private ulong sldo_debe;

        public Cliente(ulong id, string nombre, uint telefono, bool estado_credito) : base(id, nombre, telefono)
        {
            this.Estado_credito = estado_credito;
            Validar();
        }
        public bool Estado_credito { get => estado_credito; 
            set => estado_credito = value; }
        public ulong Sldo_debe { get => sldo_debe; 
            set => sldo_debe = (value >= RglsPersona.valor_nulo && estado_credito == true) ? 
                value : throw new Exception("Cliente no valido para deber"); }

        public void Validar()
        {
            Estado_credito = estado_credito;
        }

        public override string ToString()
        {
            return $"Cliente | ID: {Id} | Nombre: {Nombre} | " +
                   $"Teléfono: {Telefono} | Crédito: {Estado_credito} | Saldo debe: ${Sldo_debe}";
        }
    }
}
