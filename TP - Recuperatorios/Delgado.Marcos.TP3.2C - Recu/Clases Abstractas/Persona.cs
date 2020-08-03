using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;


        /// <summary>
        /// Propiedad de lectura y escritura atributo nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = this.ValidarNombre(value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura atributo apellido
        /// </summary>
        public string Apellido 
        { 
            get { return this.apellido; } 
            set { this.apellido = this.ValidarNombre(value); } 
        }

        /// <summary>
        /// Propiedad de lectura y escritura atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura atributo DNI
        /// </summary>
        public int Dni 
        { 
            get { return this.dni; }
            set { this.dni = this.ValidarDni(this.nacionalidad, value); } 
        }

        /// <summary>
        /// Propiedad de escritura atributo dni en formato cadena de caracteres
        /// </summary>
        public string StringDni
        {
            set { this.Dni = this.ValidarDni(this.nacionalidad, value); }
        }

        /// <summary>
        /// Constructor por defecto de clase persona
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor de clase persona
        /// </summary>
        /// <param name="nombre">nombre de persona</param>
        /// <param name="apellido">apellido de persona</param>
        /// <param name="nacionalidad">nacionalidad de nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de clase persona
        /// </summary>
        /// <param name="nombre">nombre de persona</param>
        /// <param name="apellido">apellido de persona</param>
        /// <param name="dni">dni de persona</param>
        /// <param name="nacionalidad">nacionalidad de persona</param>
        public Persona(string nombre, string apellido, int dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.Dni = dni;
        }
        /// <summary>
        /// Constructor de clase persona
        /// </summary>
        /// <param name="nombre">nombre de persona</param>
        /// <param name="apellido">apellido de persona</param>
        /// <param name="dni">dni de persona en string</param>
        /// <param name="nacionalidad">nacionalidad de persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringDni = dni;
        }

        /// <summary>
        /// Sobre escritura de metodo ToString()
        /// </summary>
        /// <returns>Retornara datos base de persona en formato string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Nacionalidad: {this.Nacionalidad}");
            return sb.ToString();
        }

        /// <summary>
        /// Validara que dni este entre 1 a 8999999 para nacionalidad arg, si es extranjero debe estar 90000000 a 99999999
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns>True= valor dni / False= lanzara exception </returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            int retorno = 0;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dni >= 1 && dni <= 89999999)
                    {
                        retorno = dni;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("DNI no corresponde a nacionaliad argentina");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dni >= 90000000 && dni <= 99999999)
                    {
                        retorno = dni;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("DNI no corresponde a nacionaliad extranjera");
                    }
                    break;
                default:
                    break;
            }
            return retorno;
        }
        /// <summary>
        /// Validara que dni no contenga letras ni caracteres especiales, ademas de que su longitud sea ente 1 a 8
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>True= valor dni / False= dni = 0 y lanzara exception</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;

            if (dato.Length > 0 && dato.Length <= 8 && (int.TryParse(dato, out dni)))
            {
                dni = ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException("Dni invalido");
            }
            return dni;
        }
        
        /// <summary>
        /// Validara atributos nombre y apellido contengan solo letras
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>True = valor dato / false= dato = (vacio)</returns>
        private string ValidarNombre (string dato)
        {
            bool flag = true;
            foreach ( char item in dato)
            {
                if (!(Char.IsLetter(item)))
                {
                    flag = false;
                    break;
                }
            }

            if (flag==true)
            {
                return dato;
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// Enumerado de tipo de nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
