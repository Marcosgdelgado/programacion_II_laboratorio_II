using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using IMostrar;


namespace _Paquete
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object envio, EventArgs e);
        public event DelegadoEstado InformaEstado;
        public delegate void DelegadoException(Exception e);
        public event DelegadoException InformarException;
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        /// <summary>
        /// Enumerado publico, contiene estados de paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        /// <summary>
        /// Propiedad de lectura y escritura para direccion de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para estado de envio
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para tracking ID
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        /// <summary>
        /// Constructor, almacenara valores de atributo
        /// por default cargara "Ingresado" en estado
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Metodo encargado de cambiar valor de estados.
        /// Invocara evento InformarEstado
        /// Inserta valor actual en SQL
        /// </summary>
        public void MockCicloDeVida()
        {
            try
            {
                do
                {
                    this.InformaEstado.Invoke(this, null);

                    Thread.Sleep(4000);

                    if (this.Estado == EEstado.Ingresado)
                    {
                        this.Estado = EEstado.EnViaje;
                    }
                    else
                    {
                        this.Estado = EEstado.Entregado;
                    }

                } while (this.Estado != EEstado.Entregado);

                this.InformaEstado.Invoke(this, null);

            }
            catch (Exception e)
            {
                this.InformarException(e);
            }


        }

        /// <summary>
        /// Metodo de interface
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>datos de paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {


            if (elemento is Paquete)
            {
                return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
            }
            else
            {
                return "";
            }

        }
        /// <summary>
        /// Sobrescritura metodo ToString
        /// </summary>
        /// <returns>datos de paquete + estado de paquete</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.MostrarDatos(this));
            sb.AppendLine(" (" + this.Estado + ")");

            return sb.ToString();
        }
        /// <summary>
        /// Operador distinto
        /// </summary>
        /// <param name="p1">valor de paquete a comparar</param>
        /// <param name="p2">valor de paquete a comparar</param>
        /// <returns>negación de operador ==</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1.trackingID == p2.trackingID);
        }

        /// <summary>
        /// Operador igual
        /// Paquetes son iguales si trackinID es el mismo
        /// </summary>
        /// <param name="p1">valor de paquete a comparar</param>
        /// <param name="p2">valor de paquete a comparar</param>
        /// <returns>retornara true o false</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }
    }
}
