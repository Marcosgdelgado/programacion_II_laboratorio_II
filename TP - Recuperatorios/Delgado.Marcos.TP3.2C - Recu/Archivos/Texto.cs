using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {
        /// <summary>
        /// Guardara valores de tipo string en archivo
        /// </summary>
        /// <param name="archivo">Path de archivo</param>
        /// <param name="datos">Valores a guardar</param>
        /// <returns> True = si se cargo correctamente / False= si no se cargaron. En caso de error lanzara exception </returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter stream = new StreamWriter(archivo, false))
                {
                    stream.Write(datos);
                    retorno = true;
                    stream.Close();
                }
            }    
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Leera valores de tipo string cargados en archivo 
        /// </summary>
        /// <param name="archivo">Path de archivo</param>
        /// <param name="datos">Valores a guardar</param>
        /// <returns>True = si se cargo correctamente / False= si no se cargaron. En caso de error lanzara exception</returns>
        public bool Leer(string archivo, out string datos)
        {
            datos = "";
            bool retorno = false;
            try
            {
                using (StreamReader stream = new StreamReader(archivo))
                {
                    datos = stream.ReadToEnd();
                    stream.Close();
                    retorno = true;
                }
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            return retorno;
        }


    }
}
