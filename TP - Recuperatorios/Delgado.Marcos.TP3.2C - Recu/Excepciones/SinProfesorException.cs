using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException:Exception
    {
        /// <summary>
        /// Inicializa mensaje de excepcion
        /// </summary>
        public SinProfesorException():base("Sin profesor asignado")
        {

        }

    }
}
