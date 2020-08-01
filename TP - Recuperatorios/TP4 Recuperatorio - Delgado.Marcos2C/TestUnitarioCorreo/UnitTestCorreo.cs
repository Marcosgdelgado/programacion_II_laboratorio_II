using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _Correo;
using _Paquete;
using _PaqueteDAO;
using _TrackingIdRepetidoException;

namespace TestUnitarioCorreo
{
    [TestClass]
    public class UnitTestCorreo
    {
        /// <summary>
        /// Testea si lista de paquetes en correo esta instanciada
        /// </summary>
        [TestMethod]
        public void TestListaCorreoInstanciada()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        /// <summary>
        /// Testea que no se pueden agregar Tracking ID duplicados
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void LoadDuplicatesTrackID()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Diego Milito 1000", "20141212");
            Paquete p2 = new Paquete("Pasaje Corbatta 150", "20141212");

            c += p1;
            c += p2;
        }

    }
}
