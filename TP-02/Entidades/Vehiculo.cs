using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{  
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// Enumerado de MARCAS
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }

        /// <summary>
        /// Enumerados de TAMANIOS
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio {get;}

        /// <summary>
        /// Constructor de clase base, inicializa datos en variables
        /// </summary>
        /// <param name="chasis"></param> Almacena num de chasis
        /// <param name="marca"></param> Almacena marca de vehiculo
        /// <param name="color"></param> Almacena color de vehiculo
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;

        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("CHASIS: {0}\r\n", this.chasis));
            sb.AppendLine(string.Format("MARCA : {0}\r\n", this.marca.ToString()));
            sb.AppendLine(string.Format("COLOR : {0}\r\n", this.color.ToString()));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        /// <summary>
        /// Operador estatico de tipo string, retorna resultados de metodo Mostrar
        /// </summary>
        /// <param name="p">Objeto vehiculo a mostrar</param>
         public static explicit operator string (Vehiculo p)
        {
            return p.Mostrar();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"> objeto vehiculo a comparar </param>
        /// <param name="v2"> objeto vehiculo a comparar</param>
        /// <returns>Retornara booleano del operador ==</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"> objeto vehiculo a comparar </param>
        /// <param name="v2"> objeto vehiculo a comparar</param>
        /// <returns>Retornara booleano del operador !=</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
    }
}
