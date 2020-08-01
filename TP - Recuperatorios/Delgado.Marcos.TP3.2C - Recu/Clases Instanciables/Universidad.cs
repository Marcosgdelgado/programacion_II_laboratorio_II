using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EntidadesAbstractas;
using Archivos;
using Excepciones;



namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// Constructor por defecto de clase Universidad
        /// Instancia lista de alumnos, jornada y profesor
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
           
        /// <summary>
        /// Propiedad de lectura y escritura de lista alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de lista profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de lista jornada
        /// </summary>
        public List<Jornada> Jornada
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Establece jordana a trves de index
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Objeto indexado</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornada.Count)
                {
                    return this.Jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.Jornada.Count)
                {
                    this.Jornada[i] = value;
                }
            }
        }
         
        /// <summary>
        /// Guardara serializacion en archivo
        /// </summary>
        /// <param name="uni"> objeto universidad </param>
        /// <returns>True= objeto serializada / en caso de error lanza exception </returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> writer = new Xml<Universidad>();

            try
            {
                return writer.Guardar("Universidad.xml", uni);
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
                
        }

        /// <summary>
        /// Lee datos de archivo serializado
        /// </summary>
        /// <returns>True= objeto deserializado, en caso de error lanza exception </returns>
        public static Universidad Leer()
        {
            Xml<Universidad> reader = new Xml<Universidad>();
            Universidad retorno = new Universidad();

            try
            {
                reader.Leer("Universidad.xml", out retorno);
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Operador + agrega clase a universidad, con alumno y profesor
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="clase"> clase </param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada;
            Profesor profesor = (g == clase);
            jornada = new Jornada(clase, profesor);

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada += alumno;
                }
            }
            g.Jornada.Add(jornada);
            return g;
        }

        /// <summary>
        /// Operador + agrega alumno a universidad
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>True = universidad con alumno cargado / false = lanza exception </returns>
        public static Universidad operator + (Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Operador + agrega profesor a universidad
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>universidad con profesor cargado</returns>
        public static Universidad operator + (Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// operador != verifica que alumno no este cargado en coleccion de universidad
        /// Reutiliza codigo de operator ==
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>True = en caso de no estar cargado / false en caso de estar cargado </returns>
        public static bool operator != (Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Operador == verifica que alumno este cargado en coleccion de universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns> true = en caso de estar cargado / false = en caso de no estarlo </returns>
        public static bool operator == (Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in g.Alumnos)
            {
                if (a == alumno)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// operador != verifica que profesor no este cargado en coleccion de universidad
        /// Reutiliza codigo de operator ==
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True = en caso de no estar cargado / false en caso de estar cargado </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Operador == verifica que profesor este cargado en coleccion de universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns> true = en caso de estar cargado / false = en caso de no estarlo </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor profesor in g.Instructores)
            {
                if ( i == profesor)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// operador != verifica que clase no este cargado en coleccion de universidad
        /// Reutiliza codigo de operator ==
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns> true = en caso de estar cargado / false = en caso de no estarlo </returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    retorno = profesor;
                    break;
                }
            }
            return retorno;
        }

        /// <returns></returns>
        /// <summary>
        /// Operador == verifica que clase este cargado en coleccion de universidad
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns> true = en caso de estar cargado / false = en caso de no estarlo / en caso de error, lanza exception</returns>
        public static Profesor operator == (Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                {
                    retorno = profesor;
                    break;
                }
            }
            if (retorno is null)
            {
                throw new SinProfesorException();
            }
            return retorno;
        }

        /// <summary>
        /// Sobrescritura de metodo ToString()
        /// </summary>
        /// <returns> string con datos de universidad </returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Sobrescritura de metodo MostrarDatos
        /// </summary>
        /// <param name="uni">universidad</param>
        /// <returns>String con valores de universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jornada");
            foreach (Jornada jornada in uni.Jornada)
            {
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("--------------------------\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Enumerado de clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

    }
    
}
