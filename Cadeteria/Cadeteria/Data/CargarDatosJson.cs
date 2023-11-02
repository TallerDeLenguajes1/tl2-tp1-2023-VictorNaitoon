using Cadeteria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Cadeteria.Data
{
    public class CargarDatosJson : AccesoADatos
    {
        public override List<Cadete> LeerArchivoCadetes(string ruta)
        {
            string archivo = File.ReadAllText(ruta);
            List<Cadete> Cadetes = JsonSerializer.Deserialize<List<Cadete>>(archivo);
            return Cadetes;
        }

        public override List<SistemaCadeteria> LeerArchivoCadeterias(string ruta)
        {
            string archivo = File.ReadAllText(ruta);
            List<SistemaCadeteria> Cadeterias = JsonSerializer.Deserialize<List<SistemaCadeteria>>(archivo);
            return Cadeterias;
        }
    }
}
