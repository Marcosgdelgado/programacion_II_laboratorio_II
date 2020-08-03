using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

using static EntidadesInstanciables.Universidad;



namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor por default de clase Alumno
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de clase Alumno con sobrecarga de BASA()
        /// </summary>
        /// <param name="id">id de alumno</param>
        /// <param name="nombre">nombre de alumno</param>
        /// <param name="apellido">apellido de alumno</param>
        /// <param name="dni">dni de alumno</param>
        /// <param name="nacionalidad">nacionalidad de alumno</param>
        /// <param name="claseQueToma">clase que toma de alumno</param>
        public Alumno(int id,string nombre, string apellido, string dni,ENacionalidad nacionalidad, EClases claseQueToma):base(id,nombre,apellido, dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor de clase Alumno con sobrecarga de BASA()
        /// </summary>
        /// <param name="id">id de alumno</param>
        /// <param name="nombre">nombre de alumno</param>
        /// <param name="apellido">apellido de alumno</param>
        /// <param name="dni">dni de alumno</param>
        /// <param name="nacionalidad">nacionalidad de alumno</param>
        /// <param name="claseQueToma">clase que toma de alumno</param>
        /// <param name="EEstadoCuenta">estado de cuenta de alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta EEstadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = EEstadoCuenta;
        }

        /// <summary>
        /// Sobrescritura de metodo mostrarDatos
        /// </summary>
        /// <returns>Datos de clase base, mas estado de cuenta y clases que toma alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre alumno: {this.Nombre} {this.Apellido}");
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"Estado de cuenta: {this.estadoCuenta}");
            sb.AppendLine($"Toma clases de: {this.claseQueToma}\n");

            return sb.ToString();
        }

        /// <summary>
        /// Operador != verifica si alumno esta asignado a clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>True= alumno esta asignado a esa clase / false= alumno no esta asignado a esa clase </returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return (a.claseQueToma != clase);
          
        }
        /// <summary>
        /// Operador == verifica si alumno esta asignado a esa clase y si su estado de cuenta es != de deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns> True= si esta asignado y no es deudor / false= no esta asignado o esta asignado y es deudor </returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
           
        }
        /// <summary>
        /// Sobrescritura de metodo abstract ParticiparEnClase
        /// </summary>
        /// <returns> string con clase que toma </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Toma clase de: {this.claseQueToma}");

            return sb.ToString();
        }
        
        /// <summary>
        /// Sobrescritura de metodo ToString
        /// </summary>
        /// <returns> string con valores de metodo mostrardatos </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Enumerado de tipo estado de cuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}
