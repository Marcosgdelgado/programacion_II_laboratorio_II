using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;


namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        static Random random;

        /// <summary>
        /// Asigna clase random
        /// </summary>
        private void _randomClases()
        {
            do
            {
                this.clasesDelDia.Enqueue((EClases)Profesor.random.Next(4));
                Thread.Sleep(300);
                

            } while (this.clasesDelDia.Count < 2);
        }

        /// <summary>
        /// Constructor default de clase Profesor
        /// Instancia Queue de tipo EClases
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
        }

        /// <summary>
        /// Constructor estatico de clase Profesor, instancia atributo estatico random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor de clase Profesor con sobrecarga de BASE()
        /// </summary>
        /// <param name="id">id de profesor</param>
        /// <param name="nombre">nombre de profesor</param>
        /// <param name="apellido">apellido de profesor</param>
        /// <param name="dni">dni de profesor</param>
        /// <param name="nacionalidad">nacionalidad de profesor </param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            _randomClases();
        }

        /// <summary>
        /// Sobrescritura de metodo MostrarDatos
        /// </summary>
        /// <returns>String con valores de clase base mas clase en la que participa</returns>
        protected override string MostrarDatos()
        {   
            return string.Format("{0} {1}\n{2}\n{3}", this.Nombre, this.Apellido, base.MostrarDatos(), this.ParticiparEnClase());   
        }

        /// <summary>
        /// Sobrescritura de metodo abstract ParticiparEnClase
        /// </summary>
        /// <returns> string con clases del dia </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del dia: ");
            foreach (EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();

        }

        /// <summary>
        /// Operador == verifica si profesor esta designado a esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        /// <summary>
        /// Operador != verifica si profesor esta designado a esa clase
        /// reutiliza codigo de operador ==
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Sobrescritura de metodo ToString
        /// </summary>
        /// <returns>String con valores de mostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
