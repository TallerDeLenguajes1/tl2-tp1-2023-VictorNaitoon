using Cadeteria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Data
{
    public class CargarDatos : AccesoADatos
    {
        public override List<Cadete> LeerArchivoCadetes(string ruta)
        {
            int autoincrementar = 0;
            List<Cadete> listadoCadetes = new List<Cadete>();
            try
            {
                var archivo = new FileStream(ruta, FileMode.Open);
                var sr = new StreamReader(archivo);
                var linea = "";
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] campos = linea.Split(",");

                    Cadete cadete = new Cadete(autoincrementar++, campos[0], campos[2], campos[1]);

                    listadoCadetes.Add(cadete);
                }
                sr.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return listadoCadetes;
        }

        public override List<SistemaCadeteria> LeerArchivoCadeterias(string ruta)
        {
            List<SistemaCadeteria> listadoCadeterias = new List<SistemaCadeteria>();
            try
            {
                var archivo = new FileStream(ruta, FileMode.Open);
                var sr = new StreamReader(archivo);
                var linea = "";
                while ((linea = sr.ReadLine()) != null)
                {
                    var campos = linea.Split(",");
                    List<Cadete> listadoCadetes = new List<Cadete>();
                    List<Pedido> listadoPedidos = new List<Pedido>();

                    SistemaCadeteria cadeteria = new SistemaCadeteria(campos[0], campos[1], listadoCadetes, listadoPedidos);

                    listadoCadeterias.Add(cadeteria);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listadoCadeterias;
        }
    }
}
