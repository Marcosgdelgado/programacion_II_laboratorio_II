using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        /// <summary>
        /// Inicializa mensaje de excepcion
        /// </summary>
        public NacionalidadInvalidaException():this("Nacionalidad invalidad.")
        {
            
        }

        /// <summary>
        /// Constructor que permite escribir un mensaje
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public NacionalidadInvalidaException(string message):base(message)
        {
            
        }




    }
}
