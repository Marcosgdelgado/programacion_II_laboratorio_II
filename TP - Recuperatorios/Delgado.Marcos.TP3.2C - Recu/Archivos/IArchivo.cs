using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo <T>
    {
        /// <summary>
        /// Guardara valores genericos en archivo
        /// </summary>
        /// <param name="archivo">Path de archivo</param>
        /// <param name="datos">Valores a guardar</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Leera valores genericos cargados en archivo
        /// </summary>
        /// <param name="archivo">Path de archivo</param>
        /// <param name="datos">Valores a guardar</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);

    }   
}
