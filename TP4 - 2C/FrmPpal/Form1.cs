using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesCorreo;
using EntidadesCorreo.Enumerados;
using EntidadesCorreo.Exceptions;
using EntidadesCorreo.ExtensionMethod;

namespace FrmPpal
{
    public partial class FormPrincipal : Form
    {
        private Correo correo;
        private Paquete paquete;

        /// <summary>
        /// Constructor Form
        /// </summary>
        public FormPrincipal()
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
                        case EEstado.Ingresado:
                            if (!lstEstadoIngresado.Items.Contains(pAux))
                            {
                                lstEstadoIngresado.Items.Add(pAux);
                            }
                            break;

                        case EEstado.EnViaje:
                            if (!lstEstadoEnViaje.Items.Contains(pAux))
                            {
                                lstEstadoEnViaje.Items.Add(pAux);
                                lstEstadoIngresado.Items.Clear();
                            }
                            break;

                        case EEstado.Entregado:
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
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
