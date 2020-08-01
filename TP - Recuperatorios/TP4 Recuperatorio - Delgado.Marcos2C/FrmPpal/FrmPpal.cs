using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Correo;
using _Paquete;
using _TrackingIdRepetidoException;
using IMostrar;
using GuardarString;
using _PaqueteDAO;


namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        private Paquete paquete;

        /// <summary>
        /// Constructor Form
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }


        /// <summary>
        /// Agrega valores cargados en txtDireccion y mtxtTrackingID a lista correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
                paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                paquete.InformaEstado += paq_InformaEstado;
                paquete.InformarException += this.paq_InformaException;

            try
            {
                correo = correo + paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            
        }

        /// <summary>
        /// Actualiza estado de paquetes
        /// </summary>
        /// 
        private void ActualizarEstado()
        {
            try
            { 
                foreach (Paquete pAux in correo.Paquetes)
                {
                    
                    switch (pAux.Estado)
                    {
                        case Paquete.EEstado.Ingresado:
                            if (!lstEstadoIngresado.Items.Contains(pAux))
                            {
                                lstEstadoIngresado.Items.Add(pAux);
                            }
                            break;

                        case Paquete.EEstado.EnViaje:
                            if (!lstEstadoEnViaje.Items.Contains(pAux))
                            {
                                lstEstadoEnViaje.Items.Add(pAux);
                                lstEstadoIngresado.Items.Clear();
                            }
                            break;

                        case Paquete.EEstado.Entregado:
                            if (!lstEstadoEntregado.Items.Contains(pAux))
                            {
                                lstEstadoEntregado.Items.Add(pAux);
                                lstEstadoEnViaje.Items.Clear();
                            }
                            break;
                    }

                }
            }catch(ConexionSqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Exception controla el error de no poder enviar el paquete a la base de datos.
        /// </summary>
        /// <param name="e"></param>
        private void paq_InformaException(Exception e)
        {
            MessageBox.Show(e.Message, "Error al enviar el paquete a la base de datos");
        }

        /// <summary>
        /// Invoca delegados si lo requiere o los actualiza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {              
                if (this.InvokeRequired)
                {
                    Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                    this.Invoke(d, new object[] { sender, e });
                }
                else
                {
                    if ( ((Paquete)sender).Estado == Paquete.EEstado.Entregado)
                    {
                        try
                        {
                            PaqueteDAO.Insertar((Paquete)sender);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al intentar agregar datos a la base de datos.\n" + ex.Message);
                        }
                    }

                    ActualizarEstado();
                }                         
        }
        
        /// <summary>
        /// Muesta lista de paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);

        }

        /// <summary>
        /// Muestra datos de paquete en rich text box
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string archivo = "salida";
            
            if (elemento != null)
            {
                if (elemento is Correo)
                {
                    rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);
                }
                else
                {
                    if (elemento is Paquete)
                    {
                        rtbMostrar.Text = ((Paquete)elemento).MostrarDatos((Paquete)elemento);
                    }
                }
    
                rtbMostrar.Text.Guardar(archivo);
            }

        }

        /// <summary>
        /// Si se cierra el formulario, aborta todos los hilos que este ejecutandose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        /// <summary>
        /// Muestra solo los datos de paquete seleccionado en entregas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
