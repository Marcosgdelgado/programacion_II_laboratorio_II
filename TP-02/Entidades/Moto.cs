using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto:Vehiculo
    {
        /// <summary>
        /// Constructor de clase, hereda de base Vehiculo
        /// </summary>
        /// <param name="marca">cargara valor de marca</param>
        /// <param name="chasis">cargara valor de chasis</param>
        /// <param name="color">cargara valor de color</param>
        public Moto(EMarca marca, string chasis, ConsoleColor color):base(chasis,marca,color)
        {

        }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Sobrescribe metodo Mostrar()
        /// </summary>
        /// <returns>Datos cargados a casa en formato string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(string.Format("TAMAÑO : {0}",  this.Tamanio));
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
