using Cadeteria.Data;
using Cadeteria.Modelos;

//Variables
string rutaCadeterias = @"C:\Users\Victo\Desktop\TallerII-2023\tl2-tp1-2023-VictorNaitoon\Cadeteria\Cadeteria\Data\Cadeteria.csv";
string rutaCadetes = @"C:\Users\Victo\Desktop\TallerII-2023\tl2-tp1-2023-VictorNaitoon\Cadeteria\Cadeteria\Data\Cadete.csv";
Random rand = new Random();
CargarDatos datos = new CargarDatos();
int cadeteriaRandom;


//Obtenemos los datos de los cadetes que tenemos en el csv
List<Cadete> listadoDeCadetes = new List<Cadete>();
listadoDeCadetes = datos.LeerArchivoCadetes(rutaCadetes);


//Creamos los pedidos
List<Pedido> listadoDePedidos = new List<Pedido>()
{
    new Pedido(1, "gorra", Estado.Entregado, "Lola", "Moreno", "155252654", "Casa Azul"),
    new Pedido(2, "zapatos", Estado.Entregado, "Andres", "Varela", "155343504", "Casa Blanca"),
    new Pedido(3, "gaseosa", Estado.Entregado, "Mario", "Capital", "155123456", "Dpto 4a"),
    new Pedido(4, "celular", Estado.EnCamino, "Juliana", "Amalia", "155252654", "Casa Naranja"),
    new Pedido(5, "mc", Estado.EnProceso, "Mariana", "Jujuy 45", "155252654", "Casa"),
    new Pedido(6, "sandwich", Estado.EnCamino, "Daniel", "Bs As 58", "155252654", "Dpto 2a"),
    new Pedido(7, "auricular", Estado.Cancelado, "Marina", "Chile 758", "155252654", "Casa Negra"),
    new Pedido(8, "sillas", Estado.Cancelado, "Julia", "Trancas", "155252654", "Casa Roja")
};
// Obtenemos los datos de la cadeteria
//Generamos un numero random para obtener los datos de cualquiera de las tres cadeterias que tengo en el csv
List<SistemaCadeteria> listadoCadeterias = new List<SistemaCadeteria>();
listadoCadeterias = datos.LeerArchivoCadeterias(rutaCadeterias);
cadeteriaRandom = rand.Next(0, listadoCadeterias.Count);
SistemaCadeteria nuevaCadeteria = new SistemaCadeteria(listadoCadeterias[cadeteriaRandom].Nombre, listadoCadeterias[cadeteriaRandom].Telefono, listadoDeCadetes, listadoDePedidos);


Console.WriteLine($"Bienvenido a la cadeteria {nuevaCadeteria.Nombre}");
int opcion, estado;
Pedido nuevoPedido = new Pedido();
do
{
    Console.WriteLine("Que desea hacer?");
    Console.WriteLine("1 - Dar de alta pedido");
    Console.WriteLine("2 - Asignar pedido a un cadete");
    Console.WriteLine("3 - Cambiar de estado del pedido");
    Console.WriteLine("4 - Reasignar el pedido a otro cadete");
    opcion = Convert.ToInt16(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            Console.WriteLine("Numero del pedido: ");
            int numeroPedido = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ingrese las observaciones del pedido");
            string observacionesPedido = Console.ReadLine();
            Console.WriteLine("Nombre del cliente: ");
            string nombreCliente = Console.ReadLine();
            Console.WriteLine("Direccion del cliente: ");
            string direccionCliente = Console.ReadLine();
            Console.WriteLine("Telefono del cliente: ");
            string telefonoCliente = Console.ReadLine();
            Console.WriteLine("Referencia de direccion del cliente: ");
            string referenciaCliente = Console.ReadLine();

            nuevaCadeteria.TomarPedido(numeroPedido, observacionesPedido, Estado.EnProceso, nombreCliente, direccionCliente, telefonoCliente, referenciaCliente);
            Console.WriteLine("Pedido tomado");
            break;
        case 2:
            Console.WriteLine("Ingrese el numero de pedido: ");
            int nPedido = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ingrese el id del cadete al que desea asignar el pedido: ");
            int idCadete = Convert.ToInt16(Console.ReadLine());
            nuevaCadeteria.AsignarCadeteAPedido(nPedido, idCadete);
            Console.WriteLine("Pedido asignado");
            break;
        case 3:
            int nuevoEstado;
            do
            {
                Console.WriteLine("A que estado desea cambiar: ");
                Console.WriteLine("1 - En proceso.");
                Console.WriteLine("2 - En camino.");
                Console.WriteLine("3 - Entregado.");
                Console.WriteLine("4 - Cancelado.");
                nuevoEstado = Int16.Parse(Console.ReadLine());
            } while (nuevoEstado < 1 && nuevoEstado > 5);
            Console.WriteLine("Ingrese el numero del pedido: ");
            int numeroDelPedido = Int16.Parse(Console.ReadLine());

            switch (nuevoEstado)
            {
                case 1:
                    nuevaCadeteria.CambiaEstado(numeroDelPedido, Estado.EnProceso);
                    Console.WriteLine("Cambio de estado a En Proceso");
                    break;
                case 2:
                    nuevaCadeteria.CambiaEstado(numeroDelPedido, Estado.EnCamino);
                    Console.WriteLine("Cambio de estado a En Camino");
                    break;
                case 3:
                    nuevaCadeteria.CambiaEstado(numeroDelPedido, Estado.Entregado);
                    Console.WriteLine("Cambio de estado a Entregado");
                    break;
                case 4:
                    nuevaCadeteria.CambiaEstado(numeroDelPedido, Estado.Cancelado);
                    Console.WriteLine("Cambio de estado a Cancelado");
                    break;
            }
            break;
        case 4:
            Console.WriteLine("Ingrese el id del pedido");
            int numPedido = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ingrese el id del cadete que desea reasignar el pedido");
            int idDelCadete = Int16.Parse(Console.ReadLine());
            nuevaCadeteria.AsignarCadeteAPedido(numPedido, idDelCadete);
            Console.WriteLine("Pedido reasignado");
            break;
    }

    Console.WriteLine("Desea salir? 1 - SI. 2 - NO");
    estado = Int16.Parse(Console.ReadLine());
} while (estado != 1);

Console.ReadKey();





