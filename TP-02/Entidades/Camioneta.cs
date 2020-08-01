using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta:Vehiculo
    {
        /// <summary>
        /// Contructor de clase, hereda de vehiculo
        /// </summary>
        /// <param name="marca">cargara valor de marca</param>
        /// <param name="chasis">cargara valor de chasis</param>
        /// <param name="color">cargara valor de color</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {

        }

        /// <summary>
        /// Sobrescribe tamanio, por default ingresa GRANDE
        /// </summary>
       protected override ETamanio Tamanio
        {
            get
            {
               return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Sobre escribe metodo Mostrar()
        /// </summary>
        /// <returns>Dator ingresados en formato string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio.ToString()));
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
