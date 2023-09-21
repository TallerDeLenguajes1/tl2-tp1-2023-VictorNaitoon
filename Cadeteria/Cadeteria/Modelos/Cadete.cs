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
        private List<Pedido>? listaPedidos;

        public int IdCadete { get => idCadete; set => idCadete = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public List<Pedido>? ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Cadete(int idCadete, string nombre, string direccion, string telefono, List<Pedido> listadoDePedidos)
        {
            IdCadete = idCadete;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ListaPedidos = listaPedidos;
        }

        public Cadete(int idCadete, string nombre, string direccion, string telefono)
        {
            IdCadete = idCadete;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;

            ListaPedidos = new List<Pedido>();
        }

        public Cadete()
        {
            
        }

        /*Asignamos un pedido a un cadete*/
        public void AsignarPedido(Pedido pedido)
        {
            ListaPedidos.Add(pedido);
        }

        /*Designamos un pedido de la lista que tiene el cadete*/
        public string DesignarPedido(int id)
        {
            string mensaje = "";
            var pedido = ListaPedidos.Find(x => x.NumeroPedido == id);
            
            if (pedido != null)
            {
                ListaPedidos.Remove(pedido);
                return mensaje = $"Se elimino el pedido numero: {pedido.NumeroPedido}, {pedido.Observaciones}";
            }

            return mensaje = $"No se encontro ningun pedido con el numero {id}";
        }

        /*Obtenemos la cantidad de pedidos entregados*/
        public int CantidadPedidosEntregados()
        {
            return ListaPedidos.Select(x => x.Estado.ToString() == "Entregado").Count();
        }

        /*Obtenemos el total que cobrar el cadete al terminar la jornada por pedido entregado*/
        public double JornalACobrar()
        {
            return CantidadPedidosEntregados() * 500;
        }

        /*Obtenemos la cantidad de pedidos que tiene el cadete*/
        public int CantidadPedidosTotal()
        {
            return ListaPedidos.Count();
        }

        /*Obtenemos la informacion de un cadete*/
        public string GetInformacionCadete()
        {
            string informacion = $"Numero identificador: {IdCadete}, Cadete: {Nombre}, Telefono: {Telefono}, Direccion: {Direccion} \n";
            return informacion;
        }


    }
}
