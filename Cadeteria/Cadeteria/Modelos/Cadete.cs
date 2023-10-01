using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Modelos
{
    public class Cadete
    {
        private int idCadete;
        private string? nombre;
        private string? direccion;
        private string? telefono;

        public int IdCadete { get => idCadete; set => idCadete = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telefono { get => telefono; set => telefono = value; }

        public Cadete(int idCadete, string nombre, string direccion, string telefono, List<Pedido> listadoDePedidos)
        {
            IdCadete = idCadete;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ListaPedidos = listaPedidos;
        }

        /*Obtenemos la informacion de un cadete*/
        public string GetInformacionCadete()
        {
            string informacion = $"Numero identificador: {IdCadete}, Cadete: {Nombre}, Telefono: {Telefono}, Direccion: {Direccion} \n";
            return informacion;
        }


    }
}
