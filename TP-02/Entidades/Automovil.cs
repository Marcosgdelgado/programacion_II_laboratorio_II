using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    

    public class Automovil:Vehiculo
    {
        /// <summary>
        /// Enumerado de tipo automovil
        /// </summary>
        public enum ETipo { Monovolumen, Sedan }

        private ETipo tipo;

        /// <summary>
        /// Sobrecarga de constructor, por defecto tipo monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color): this(marca, chasis, color, ETipo.Monovolumen)
        {

        }
        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">cargara valor de marca</param>
        /// <param name="chasis">cargara valor de chasis</param>
        /// <param name="color">cargara valor de color</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo): base( chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Los automoviles son medianos
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

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio.ToString()));
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
