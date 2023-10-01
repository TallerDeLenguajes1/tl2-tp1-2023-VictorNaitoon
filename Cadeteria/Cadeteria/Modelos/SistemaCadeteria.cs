using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Modelos
{
    public class SistemaCadeteria
    {
        private const int VALOR_PEDIDO = 500;

        private string? nombre;
        private string? telefono;
        private List<Cadete>? listaCadetes;
        private List<Pedido>? listaPedidos;

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public List<Cadete>? ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Pedido>? ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public SistemaCadeteria(string nombre, string telefono, List<Cadete> listadoDeCadetes, List<Pedido>? listadoDePedidos)
        {
            Nombre = nombre;
            Telefono = telefono;
            ListaCadetes = listadoDeCadetes;
            ListaPedidos = listadoDePedidos;
        }
        public SistemaCadeteria()
        {
            
        }

        /* Agregamos un cadete a la lista */
        public void AgregarCadete(Cadete cadete)
        {
            ListaCadetes.Add(cadete);
        }

        /* Eliminamos un cadete por id */
        public string EliminarCadete(int idCadete)
        {
            string informacion = "";
            var cadeteEliminar = ListaCadetes.Find(x => x.IdCadete == idCadete);

            if(cadeteEliminar != null)
            {
                ListaCadetes.Remove(cadeteEliminar);
                informacion += $"Se elimino el cadete {cadeteEliminar.Nombre} de identificacion: {cadeteEliminar.IdCadete}. \n";
            } else
            {
                informacion += $"No se encontro ningun cadete con el numero identificador: {idCadete}. \n";
            }

            return informacion;
        }

        /* Obtenemos la informacion de la cadeteria */
        public string GetInformacionCadeteria()
        {
            string info = $"Cadeteria: {Nombre}, Telefono: {Telefono}, Cadetes: ";
            foreach (var cadete in ListaCadetes)
            {
               info += cadete.GetInformacionCadete();
            }
            return info;
        }

        /* Mostramos el listado de los cadetes que hay en la cadeteria */
        public string MostrarListadoCadetes()
        {
            string info = "Listado de cadetes\n";
            foreach (var cadete in ListaCadetes)
            {
                info += cadete.GetInformacionCadete();
            }
            return info;
        }

        //Obtenemos el listado de los cadetes que tiene la cadeteria
        public List<Cadete> GetListadoCadetes()
        {
            return listaCadetes;
        }

        /* Obtenemos un cadete por id */
        public string GetCadete(int id)
        {
            var cadete = ListaCadetes.Find(x => x.IdCadete == id);
            return cadete.GetInformacionCadete();
        }



        /* Obtenemos la cantidad total de pedidos */
        public int GetCantidadTotalPedidos()
        {
            return ListaPedidos.Count;
        }

        /* Calculamos el jornal para los cadetes */
        public double JornalACobrar(int idCadete)
        {
            return ListaPedidos.Count(x => x.Cadete.IdCadete == idCadete && x.Estado == Estado.Entregado)*VALOR_PEDIDO;
        }

        /* Creamos el pedido y lo agregamos a la lista*/
        public void TomarPedido(int numeroPedido, string observacionPedido, Estado estado, string nombreCliente, string direccionCliente, string telefonoCliente, string refetenciaDireccion)
        {
            Pedido pedido = new Pedido(numeroPedido, observacionPedido, estado, nombreCliente, direccionCliente, telefonoCliente, refetenciaDireccion);
            ListaPedidos.Add(pedido);
        }

        /* Asignamos un cadete para un pedido */
        public void AsignarCadeteAPedido(int numeroPedido, int idCadete)
        {
            var pedido = ListaPedidos.Find(x => x.NumeroPedido == numeroPedido);
            var cadete = ListaCadetes.Find(x => x.IdCadete == idCadete);
            pedido.AsignarCadete(cadete);
        }


        

        /*Cambiamos de Estado un pedido*/
        public void CambiaEstado(int idPedido, Estado estado)
        {
            var pedido = ListaPedidos.Find(x => x.NumeroPedido == idPedido);
            pedido.Estado = estado;
        }

        

    }
}
