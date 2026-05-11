using CL_Taller.CPersona;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    internal class Vehiculo
    {
        private string placa;
        private string marca;
        private string modelo;
        private ushort ano;
        private Cliente dueno_vehiculo;

        public Vehiculo(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo)
        {
            this.Placa = placa;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Dueno_vehiculo = dueno_vehiculo;
        }

        public string Placa { get => placa; 
            set => placa = System.Text.RegularExpressions.Regex.IsMatch(value, RglsVehiculo.regex_placa) ?
                value : throw new Exception("Placa no valida"); }
        public string Marca { get => marca; 
            set => marca = System.Text.RegularExpressions.Regex.IsMatch(value, RglsVehiculo.regex_marca ) ?
                value: throw new Exception("Marca no valida"); }
        public string Modelo { get => modelo; 
            set => modelo = System.Text.RegularExpressions.Regex.IsMatch(value, RglsVehiculo.regex_modelo) ?
                value : throw new Exception("Modelo no valido"); }
        public ushort Ano { get => ano; 
            set => ano = (ano >= RglsVehiculo.ano_min && ano <= DateTime.Now.Year + RglsVehiculo.ano_max_sum) ?
                value : throw new Exception("Año no valido"); }
        internal Cliente Dueno_vehiculo { get => dueno_vehiculo; 
            set => dueno_vehiculo = value; }
    }
}
