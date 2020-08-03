using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

using static EntidadesInstanciables.Universidad;
using Archivos;
using Excepciones;


namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clases;
        private Profesor instructor;

        /// <summary>
        /// Propiedad de lectura escritura de lista alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }

        }

        /// <summary>
        /// Propiedad de lectura escritura de clase
        /// </summary>
        public EClases Clase
        {
            get { return this.clases; }
            set { this.clases = value; }
        }

        /// <summary>
        /// Propiedad de lectura escritura de instructor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        /// <summary>
        /// Constructor privado de clase Jornada, instancia lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de clase Jornada
        /// </summary>
        /// <param name="clases">clases de jornada</param>
        /// <param name="instructor">instructor de jornada</param>
        public Jornada(EClases clases, Profesor instructor):this()
        {
            this.Clase = clases;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Metodo para guardar en formato texto jornada en archivo
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns> Archivo txt con jornada / en caso de fallar escritura lanzara exception </returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto writer = new Texto();

            try
            {
                return writer.Guardar("Jornada.txt",jornada.ToString());
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

        }

        /// <summary>
        /// Metodo para leer archivo en formato txt
        /// </summary>
        /// <returns> Valores escritos en archivo, en caso de fallar lectura lanzara exption </returns>
        public static string Leer()
        {
            Texto reader = new Texto();
            string retorno = "";

            try
            {
                reader.Leer("Jornada.txt", out retorno);
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Operador != reutiliza codigo operador ==
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns> Negara resultado operador ==</returns>
        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Operador == recorre coleccion de alunmos en clase jornada, verifica si alumno esta en dicha coleccion
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>True = en caso de estar cargado / False en caso de no estarlo </returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        
        /// <summary>
        /// Operador + agregara alumno en jornada en caso de no estar cargado
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns> true = jornada con nuevo alumno / false = lanzara exption </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }
        
        /// <summary>
        /// Sobrescritura metodo ToString
        /// </summary>
        /// <returns> string con clase dictada, instructor y alumnos que asisten </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Clase de {this.Clase} por {this.Instructor}");
            sb.AppendLine("Alumnos: ");

            foreach (Alumno alumno in this.Alumnos)
            {
                sb.Append(alumno.ToString());
            }
            return sb.ToString();
        }

    }
}
