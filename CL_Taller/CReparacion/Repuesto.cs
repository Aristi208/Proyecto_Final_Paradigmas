using CL_Taller.CVehiculo;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CL_Taller.CReparacion
{
    public class Repuesto : IValidable
    {
        private string nombre;
        private string proveedor;
        private DateTime fecha_compra;
        private ulong valor;   

        public Repuesto(string nombre, string proveedor, DateTime fecha_compra, ulong valor)
        {
            this.Nombre = nombre;
            this.Proveedor = proveedor;
            this.Fecha_compra = fecha_compra;
            this.Valor = valor;
            Validar();
        }
        public string Nombre { get => nombre; 
            set => nombre = System.Text.RegularExpressions.Regex.IsMatch(value, RglsReparacion.regex_nombre) ?
                value: throw new Exception("Nombre no valido"); }
        public string Proveedor { get => proveedor; 
            set => proveedor = System.Text.RegularExpressions.Regex.IsMatch(value, RglsReparacion.regex_proveedor) ?
                value : throw new Exception("Proveedor no valido"); }
        public DateTime Fecha_compra { get => fecha_compra; 
            set => fecha_compra = (value >= DateTime.Now.AddYears(RglsReparacion.ano_min) && value <= DateTime.Now) ?
                value : throw new Exception("Fecha de compra no valida, solo repuestos con menos de 10 años de antiguedad"); }
        public ulong Valor { get => valor; 
            set => valor = value >= RglsReparacion.valor_nulo ? 
                value : throw new Exception("No se puede un valor menor a 0"); }
        
        public void Validar()
        {
            this.Nombre = nombre;
            this.Proveedor = proveedor;
            this.Fecha_compra = fecha_compra;
            this.Valor = valor;
        }



        public override string ToString()
        {
            return $"Repuesto: {Nombre} | Proveedor: {Proveedor} | " +
                   $"Fecha compra: {Fecha_compra:dd/MM/yyyy} | Valor: ${Valor}";
        }

    }
}
