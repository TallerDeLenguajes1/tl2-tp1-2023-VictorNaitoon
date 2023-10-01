using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Modelos
{
    public enum Estado
    {
        EnProceso,
        EnCamino,
        Entregado,
        Cancelado
    }
    public class Pedido
    {
        private int numeroPedido;
        private string? observaciones;
        private Cliente? cliente;
        private Estado estado;
        private Cadete cadete;

        public int NumeroPedido { get => numeroPedido; set => numeroPedido = value; }
        public string? Observaciones { get => observaciones; set => observaciones = value; }
        public Cliente? Cliente { get => cliente; set => cliente = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }

        public Pedido(int numeroPedido, string observaciones, Estado estado, string nombreCliente, string direccion, string telefono, string direccionReferencia)
        {
            NumeroPedido = numeroPedido;
            Observaciones = observaciones;
            Estado = estado;
            Cliente = new Cliente(nombreCliente, direccion, telefono, direccionReferencia);
        }

        public Pedido()
        {
            
        }

        /*Asignamos un cadete*/
        public void AsignarCadete(Cadete cadete)
        {
            Cadete = cadete;
        }

        /*Obtenemos la direccion de un cliente*/
        public string GetDireccionCliente()
        {
            string info = $"Direccion: {cliente.Direccion}";
            return info;
        }

        /*Obtenemos los datos de los clientes*/
        public string GetDatosClientes()
        {
            string info = $"Nombre: {cliente.Nombre}. Tefono: {cliente.Telefono}. Referencia de Direccion: {cliente.ReferenciaDireccion}";
            info += GetDireccionCliente();
            return info;
        }

        /*Obtenemos la informacion de un pedido*/
        public string GetDatosPedidos()
        {
            string info = "";
            info += $"Numero del pedido: {NumeroPedido}, Detalles del pedido: {Observaciones}, Cliente: ";
            info += Cliente.GetDatosClientes();
            info += "Informacion del cadete que tiene el pedido: ";
            info += Cadete.GetInformacionCadete();
            return info;
        }
    }
}
