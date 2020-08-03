using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : class, new()
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
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
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
            
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    datos = (T)xml.Deserialize(reader);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
