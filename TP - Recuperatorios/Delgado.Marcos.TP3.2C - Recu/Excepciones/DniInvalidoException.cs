using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
     public class DniInvalidoException : Exception
    {
        private string mensaje;

        /// <summary>
        /// Inicializa mensaje de excepcion
        /// </summary>
        public DniInvalidoException() : this("DNI invalido.")
        {

        }

        /// <summary>
        /// Inicializa mensaje de excepcion
        /// </summary>
        public DniInvalidoException(Exception e) : base("DNI invalido.", e)
        {
        }

        /// <summary>
        /// Constructor que permite escribir un mensaje
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public DniInvalidoException(string message) : base(message)
        {
            this.mensaje = message;
        }


        /// <summary>
        /// Constructor que permite escribir un mensaje y detallar la excepcion
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion a detallar</param>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {
            this.mensaje = message;
        }

    }
}
