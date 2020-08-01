using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : class
    {
        /// <summary>
        /// Guardara serializacion en archivo
        /// </summary>
        /// <param name="archivo">Path de archivo</param>
        /// <param name="datos">serializacion</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (TextWriter writer = new StreamWriter(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
                    writer.Close();
                    retorno = true;
                }
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Deserializa archivo
        /// </summary>
        /// <param name="archivo">Path de archivo</param>
        /// <param name="datos">serializacion</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                using (TextReader reader = new StreamReader(archivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    datos = (T)xml.Deserialize(reader);
                    reader.Close();
                    retorno = true;
                }
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
