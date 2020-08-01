using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCorreo
{   
    /// <summary>
    /// Interface generica
    /// </summary>
    /// <typeparam name="T">Tipo generico</typeparam>
    public interface IMostrar <T>
    {
        /// <summary>
        /// Metodo de interface
        /// </summary>
        /// <param name="elemento">Tipo generico</param>
        /// <returns>cadena de caracteres</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
