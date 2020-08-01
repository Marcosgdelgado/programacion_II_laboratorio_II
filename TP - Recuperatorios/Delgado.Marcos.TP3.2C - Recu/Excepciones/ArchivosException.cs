using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Inicializa mensaje de excepcion
        /// </summary>
        public ArchivosException(Exception innerException) : base("Error en el archivo", innerException)
        {

        }

    }
}
