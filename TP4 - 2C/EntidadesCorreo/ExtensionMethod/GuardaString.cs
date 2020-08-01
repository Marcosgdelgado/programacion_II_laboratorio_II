using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCorreo.ExtensionMethod
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo estatico de extension de clase string
        /// </summary>
        /// <param name="mensaje">Texto que almacenara en archivo</param>
        /// <param name="archivo">Nombre de archivo a escribir</param>
        /// <returns>True, si guardo/sobrescribio</returns>
        public static bool Guardar(this string mensaje, string archivo)
        {
            string pathFile = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".txt");
            StreamWriter sw = null;
            
            bool retorno = true;

            try
            {
                sw = new StreamWriter(pathFile, true);
                sw.Write(mensaje);
            }
            catch(Exception)
            {
                retorno = false;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                
            }
            return retorno;
        }
    }
}
