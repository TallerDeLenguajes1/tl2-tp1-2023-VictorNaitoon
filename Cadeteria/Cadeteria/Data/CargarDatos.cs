using Cadeteria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Data
{
    public class CargarDatos
    {
        public List<string> LeerCSV(string ruta)
        {
            List<string> lista = new List<string>();
            try
            {
                var archivo = new FileStream(ruta, FileMode.Open);
                var sr = new StreamReader(archivo);
                var linea = "";
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] campos = linea.Split(",");
                    foreach (var campo in campos)
                    {
                        lista.Add(campo);
                    }
                }
                sr.Close();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }

        public List<Cadete> LeerCSVCadetes(string ruta)
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
                    List<Pedido> listadoPedidos = new List<Pedido>();

                    Cadete cadete = new Cadete(autoincrementar++, campos[0], campos[2], campos[1], listadoPedidos);

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

        public List<SistemaCadeteria> LeerCSVCadetereias(string ruta)
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

                    SistemaCadeteria cadeteria = new SistemaCadeteria(campos[0], campos[1], listadoCadetes);

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
