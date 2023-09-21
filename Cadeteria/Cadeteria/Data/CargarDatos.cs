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
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }
    }
}
