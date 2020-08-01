using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntidadesCorreo;
using EntidadesCorreo.Exceptions;

namespace EntidadesCorreo
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

       /// <summary>
       /// Propiedad de lectura y escritura del tipo lista paquetes
       /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        /// <summary>
        /// Constructor publico de correo
        /// Instancia lista de hilos y paquqetes
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();

            this.paquetes = new List<Paquete>();

        }

        /// <summary>
        /// Metodo encargado de finalizar hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                if (t.IsAlive)
                {
                    t.Abort();
                }
            }
        }

        /// <summary>
        /// Metodo de interface encargado de retornar lista de paquetes
        /// </summary>
        /// <param name="elementos">tipo lista paquete</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            if (elementos is Correo)
            {
                foreach (Paquete pAux in ((Correo)elementos).Paquetes)
                {
                    sb.AppendLine(pAux.ToString());
                }
            }
           
            return sb.ToString(); 
        }

        /// <summary>
        /// Operador encargado de agregar paquete a lista correo
        /// agregara hilo a lista de hilos
        /// Inicia hilo MockCicloDeVida
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>Retornara exception en caso de cargar paquete duplicado. Si no es duplicado cargara en lista y devuelve correo </returns>
        public static Correo operator + (Correo c, Paquete p)
        {
            Thread t = new Thread(p.MockCicloDeVida);

            foreach (Paquete pAux in c.paquetes)
            {
                if (pAux == p)
                {
                    throw new TrackingIdRepetidoException("Error, paquete duplicado");
                }
            }
            
            c.paquetes.Add(p);
            c.mockPaquetes.Add(t);
            t.Start(); 

            return c;


        }
    }
}
