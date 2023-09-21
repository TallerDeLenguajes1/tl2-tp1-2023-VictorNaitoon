using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Modelos
{
    public class SistemaCadeteria
    {
        private string? nombre;
        private string? telefono;
        private List<Cadete>? listaCadetes;

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public List<Cadete>? ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

        public SistemaCadeteria(string nombre, string telefono, List<Cadete> listadoDeCadetes)
        {
            Nombre = nombre;
            Telefono = telefono;
            ListaCadetes = listadoDeCadetes;
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
            info += "\n";
            return info;
        }

        /* Obtenemos el listado de los cadetes que hay en la cadeteria */
        public string GetListadoCadetes()
        {
            string info = "Listado de cadetes\n";
            foreach (var cadete in ListaCadetes)
            {
                info += cadete.GetInformacionCadete();
            }
            return info;
        }

        /* Obtenemos un cadete por id */
        public string GetCadete(int id)
        {
            var cadete = ListaCadetes.Find(x => x.IdCadete == id);
            return cadete.GetInformacionCadete();
        }

        /*Creamos el pedido y se lo asigamos a un cadete*/
        public void TomarPedido(int NuemeroPedido, string DetallePedido, Estado Estado, string NombreCliente, string Direccion, string Telefono, string RefetenciaDireccion)
        {
            int maximo = 0, idCadete = 0;
            Pedido pedido = new Pedido(NuemeroPedido, DetallePedido, Estado.EnProceso, NombreCliente, Direccion, Telefono, RefetenciaDireccion);
            foreach (var persona in ListaCadetes)
            {
                if (persona.ListaPedidos.Count > maximo)
                {
                    maximo = persona.ListaPedidos.Count;
                    idCadete = persona.IdCadete;
                }
            }
            var cadete = ListaCadetes.Find(x => x.IdCadete == idCadete);
            cadete.AsignarPedido(pedido);
        }

        /*Cambiamos de Estado un pedido*/
        public void CambiaEstado(int idPedido, Estado estado, int idCadete)
        {
            var cadete = ListaCadetes.Find(x => x.IdCadete == idCadete);
            var pedido = cadete.ListaPedidos.Find(x => x.NumeroPedido == idPedido);
            pedido.Estado = estado;
        }

        /*Reasignamos un pedido a otro cadete*/
        public string ReasignarPedido(Pedido pedido, int idCadete)
        {
            string info = "";
            var cadete = ListaCadetes.Find(x => x.IdCadete == idCadete);

            if (cadete == null)
            {
                info += "No se encontro ningun cadete correspondiente al id que proporciono\n";
            }

            cadete.AsignarPedido(pedido);
            info += "Se reasigno el pedido a otro cliente con exito";
            return info;
        }

    }
}
