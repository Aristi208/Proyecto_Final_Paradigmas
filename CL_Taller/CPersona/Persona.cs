using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CL_Taller.CPersona
{
    public abstract class Persona : IValidable
    {
        private ulong id;
        private string nombre;
        private uint telefono;

        public Persona(ulong id, string nombre, uint telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Telefono = telefono;
            Validar();
        }
        public ulong Id { get => id; 
            set => id = System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), RglsPersona.regex_id) ? 
                value : throw new Exception("El id no es valido"); }
        public string Nombre { get => nombre; 
            set => nombre = System.Text.RegularExpressions.Regex.IsMatch(value, RglsPersona.regex_nombre) ?
                value : throw new Exception("El nombre no es valido"); }
        public uint Telefono { get => telefono; 
            set => telefono = System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), RglsPersona.regex_telefono) ?
                value : throw new Exception("El telefono no es valido"); }

        public void Validar()
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
