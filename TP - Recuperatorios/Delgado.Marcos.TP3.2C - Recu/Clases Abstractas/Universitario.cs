using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructo por defecto de clase Universitario
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor de clase con sobrecarga de BASE()
        /// </summary>
        /// <param name="legajo">legajo de universitario</param>
        /// <param name="nombre">nombre de universitario</param>
        /// <param name="apellido">apellido de universitario</param>
        /// <param name="dni">dni de universitario</param>
        /// <param name="nacionalidad">nacionalidad de universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Propiedad de lectura y escritura de Legajo
        /// </summary>
        public int Legajo 
        {
            get { return legajo; } 
            set { legajo = value;}
        }
        /// <summary>
        /// Sobreescritura de metodo Equals, verifica que el obejeto sea del tipo Universitario 
        /// y si lo es retorna el objeto casteado, si no lo es retornara false
        /// </summary>
        /// <param name="obj">Objeto a ser verificado</param>
        /// <returns>True= obj de tipo Universitario / false = si obj != uni</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return (((Universitario)obj) == this);
            }
            return false;
        }

        /// <summary>
        /// Muestra datos de clase base mas numero de legajo
        /// </summary>
        /// <returns>Cadena de caracteres con datos</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + $"Numero de legajo:{this.legajo}\n";
        }
        /// <summary>
        /// Operador == compara DNI o legajo de universitarios
        /// </summary>
        /// <param name="pg1">Valor a comparar con PG2</param>
        /// <param name="pg2">Valor a comparar con PG1</param>
        /// <returns> True = en caso de ser iguales / False en caso contrario </returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Dni == pg2.Dni || pg1.legajo==pg2.legajo)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        /// <summary>
        /// Operador != reutiliza codigo de operador == pero niega el resultado.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns> true = Si son distintos / False = si son iguales </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Declaracion de metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();


    }
}
