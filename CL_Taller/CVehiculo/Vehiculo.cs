using CL_Taller.CPersona;
using CL_Taller.CReparacion;
using CL_Taller.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Taller.CVehiculo
{
    public abstract class Vehiculo : IVehiculo, IValidable
    {
        protected string placa;
        protected string marca;
        protected string modelo;
        protected ushort ano;
        protected Cliente dueno_vehiculo;

        public Vehiculo(string placa, string marca, string modelo, ushort ano, Cliente dueno_vehiculo)
        {
            this.Placa = placa;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Dueno_vehiculo = dueno_vehiculo;
            Validar();
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
            set => ano = (value >= RglsVehiculo.ano_min && value <= DateTime.Now.Year + RglsVehiculo.ano_max_sum) ?
                value : throw new Exception("Año no valido"); }
        internal Cliente Dueno_vehiculo { get => dueno_vehiculo; 
            set => dueno_vehiculo = value; }

        public abstract string CalibrarSensores();

        public abstract string CambiarLlantas();

        public abstract string CambiarPieza(Repuesto repuesto);

        public abstract string DesconexionBateria();

        public abstract string Escaner();

        public abstract string PuestaAPunto();

        public void Validar()
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Dueno_vehiculo = dueno_vehiculo;
        }

        public override string ToString()
        {
            return $"Vehículo | Placa: {Placa} | Marca: {Marca} | Modelo: {Modelo} | Año: {Ano}";
        }
       
    }
}
