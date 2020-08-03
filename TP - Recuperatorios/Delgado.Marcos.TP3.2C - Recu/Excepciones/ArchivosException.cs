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
        public ArchivosException():this("Error en Archivo")
        {

        }

        public ArchivosException(Exception innerException):this(innerException, innerException.Message)
        {

        }

        public ArchivosException(string message):this(null,message)
        {
        }

        public ArchivosException(Exception innerException, string message):base(message, innerException)
        {
        }

    }
}
