using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Modelos
{
    public class Cliente
    {
        private string? nombre;
        private string? direccion;
        private string? telefono;
        private string? referenciaDireccion;

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public string? ReferenciaDireccion { get => referenciaDireccion; set => referenciaDireccion = value; }

        public Cliente(string nombre, string direccion, string telefono, string referenciaDireccion)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ReferenciaDireccion = referenciaDireccion;
        }

        public string GetDatosClientes()
        {
            string info = "";
            info += $"Nombre: {Nombre}, Direccion: {Direccion}, {ReferenciaDireccion}, Telefono: {Telefono} \n";
            return info;
        }

    }
}
