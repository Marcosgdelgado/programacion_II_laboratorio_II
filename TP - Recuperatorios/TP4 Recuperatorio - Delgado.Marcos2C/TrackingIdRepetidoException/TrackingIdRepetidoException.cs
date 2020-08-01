using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _TrackingIdRepetidoException
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Constructor que permite escribir un mensaje
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        public TrackingIdRepetidoException(string mensaje) : this(mensaje, null)
        {

        }
        /// <summary>
        /// Constructor que permite escribir un mensaje y detallar la excepcion
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion a detallar</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }

    public class ConexionSqlException : Exception
    {
        /// <summary>
        /// Constructor que permite escribir un mensaje
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        public ConexionSqlException(string mensaje) : this(mensaje, null)
        {

        }
        /// <summary>
        /// Constructor que permite escribir un mensaje y detallar la excepcion
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion a detallar</param>
        public ConexionSqlException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
