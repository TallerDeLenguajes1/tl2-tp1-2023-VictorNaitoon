using Cadeteria.Data;
using Cadeteria.Modelos;

//Variables
string rutaCadeteria = @"C:\Users\Victo\Desktop\TallerII-2023\tl2-tp1-2023-VictorNaitoon\Cadeteria\Cadeteria\Data\Cadeteria.csv";
string rutaCadete = @"C:\Users\Victo\Desktop\TallerII-2023\tl2-tp1-2023-VictorNaitoon\Cadeteria\Cadeteria\Data\Cadete.csv";
int cadeteriaRandom, autoincrementar = 0;
Random rand = new Random();
CargarDatos datos = new CargarDatos();


//Obtenemos los datos de los cadetes que tenemos en el csv
var listaObtenida = new List<string>();
listaObtenida = datos.LeerCSV(rutaCadete);
List<Cadete> listadoDeCadetes = new List<Cadete>();

/**/
for(int i = 0; i < listaObtenida.Count; i += 3)
{
    if(i + 2 < listaObtenida.Count)
    {
        Cadete nuevoCadete = new Cadete(autoincrementar++, listaObtenida[i], listaObtenida[i + 2], listaObtenida[i + 1]);
        listadoDeCadetes.Add(nuevoCadete);
    } else
    {
        Console.WriteLine("No hay suficientes elementos en listaObtenida para crear un Cadete.");
    }
}


// Obtenemos los datos de la cadeteria
//Generamos un numero random para obtener los datos de cualquiera de las tres cadeterias que tengo en el csv
var listas = new List<string>();
listas = datos.LeerCSV(rutaCadeteria);
cadeteriaRandom = rand.Next(0, listas.Count);
SistemaCadeteria nuevaCadeteria = new SistemaCadeteria(listas[0], listas[1], listadoDeCadetes);


/*Creamos los pedidos*/
Pedido pedido1 = new Pedido(1, "gorra", Estado.Entregado, "Lola", "Moreno", "155252654", "Casa Azul");
Pedido pedido2 = new Pedido(2, "zapatos", Estado.Entregado, "Andres", "Varela", "155343504", "Casa Blanca");
Pedido pedido3 = new Pedido(3, "gaseosa", Estado.Entregado, "Mario", "Capital", "155123456", "Dpto 4a");
Pedido pedido4 = new Pedido(4, "celular", Estado.EnCamino, "Juliana", "Amalia", "155252654", "Casa Naranja");
Pedido pedido5 = new Pedido(5, "mc", Estado.EnProceso, "Mariana", "Jujuy 45", "155252654", "Casa");
Pedido pedido6 = new Pedido(6, "sandwich", Estado.EnCamino, "Daniel", "Bs As 58", "155252654", "Dpto 2a");
Pedido pedido7 = new Pedido(7, "auricular", Estado.Cancelado, "Marina", "Chile 758", "155252654", "Casa Negra");
Pedido pedido8 = new Pedido(8, "sillas", Estado.Cancelado, "Julia", "Trancas", "155252654", "Casa Roja");


/*Asignamos esos pedidos que creamos a los cadetes que tenemos*/
listadoDeCadetes[0].AsignarPedido(pedido1);
listadoDeCadetes[0].AsignarPedido(pedido2);
listadoDeCadetes[0].AsignarPedido(pedido5);
listadoDeCadetes[1].AsignarPedido(pedido8);
listadoDeCadetes[1].AsignarPedido(pedido3);
listadoDeCadetes[2].AsignarPedido(pedido6);
listadoDeCadetes[2].AsignarPedido(pedido7);
listadoDeCadetes[3].AsignarPedido(pedido4);



Console.WriteLine($"Bienvenido a la cadeteria {nuevaCadeteria.Nombre}");
int opcion, estado;
Pedido nuevoPedido = new Pedido();
do
{
    Console.WriteLine("Que desea hacer?");
    Console.WriteLine("1 - Dar de alta pedido");
    Console.WriteLine("2 - Cambiar de estado del pedido");
    Console.WriteLine("3 - Reasignar el pedido a otro cadete");
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
            Console.WriteLine("Pedido tomado y asignado al cadete que menos pedidos tiene");
            break;
        case 2:
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
            Console.WriteLine("Id del cadete encargado de su pedido: ");
            int numeroCadete = Int16.Parse(Console.ReadLine());

            switch (nuevoEstado)
            {
                case 1:
                    nuevaCadeteria.CambiaEstado(numeroDelPedido, Estado.EnProceso, numeroCadete);
                    Console.WriteLine("Cambio de estado a En Proceso");
                    break;
                case 2:
                    nuevaCadeteria.CambiaEstado(numeroDelPedido, Estado.EnCamino, numeroCadete);
                    Console.WriteLine("Cambio de estado a En Camino");
                    break;
                case 3:
                    nuevaCadeteria.CambiaEstado(numeroDelPedido, Estado.Entregado, numeroCadete);
                    Console.WriteLine("Cambio de estado a Entregado");
                    break;
                case 4:
                    nuevaCadeteria.CambiaEstado(numeroDelPedido, Estado.Cancelado, numeroCadete);
                    Console.WriteLine("Cambio de estado a Cancelado");
                    break;
            }
            break;
        case 3:
            int idCadete;
            Console.WriteLine("Ingrese el id del cadete que desea reasignar el pedido");
            idCadete = Int16.Parse(Console.ReadLine());
            Console.WriteLine(nuevaCadeteria.ReasignarPedido(pedido2, idCadete));
            break;
    }

    Console.WriteLine("Desea salir? 1 - SI. 2 - NO");
    estado = Int16.Parse(Console.ReadLine());
} while (estado != 1);

Console.ReadKey();





