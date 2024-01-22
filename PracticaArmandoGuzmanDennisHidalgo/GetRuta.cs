using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArmandoGuzmanDennisHidalgo
{
    public class GetRuta
    {
        public static String obtenerRuta(String nombreBD)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, nombreBD);
        }
    }
}
