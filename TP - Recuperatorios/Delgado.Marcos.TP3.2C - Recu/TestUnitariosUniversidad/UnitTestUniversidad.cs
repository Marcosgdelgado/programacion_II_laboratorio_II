using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;

namespace TestUnitariosUniversidad
{
    [TestClass]
    public class UnitTestUniversidad
    {
        /// <summary>
        /// Test Unitario que comprueba que al agregar dos objetos de tipo <see cref="Alumno"/> a una <see cref="Universidad"/>, se lance la excepcion <see cref="AlumnoRepetidoException"/>.
        /// </summary>
        [TestMethod]
        public void AlumnoRepetidoExceptionTest()
        {
            //Se instancian dos alumnos con mismo numero de DNI
            Alumno alumno = new Alumno(1000, "Diego", "Milito", "25460122", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno segundoAlumno = new Alumno(589, "Gustavo", "Bou", "25460122", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            //Se instancia una Universidad en la que se agregaran los alumnos
            Universidad universidad = new Universidad();
            try
            {
                //Se agregan los alumnos.
                universidad += alumno;
                universidad += segundoAlumno;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Test Unitario que comprueba que al instanciar un <see cref="Alumno"/> con formato invalido de DNI, se lance la excepcion <see cref="DniInvalidoException"/>
        /// </summary>
        [TestMethod]
        public void DniInvalidoExceptionTest()
        {
            //Dni con letra
            try
            {
                Alumno alumno = new Alumno(22, "Sacha", "Lopez", "66pqo8", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //Dni con puntos
            try
            {
                Alumno alumno = new Alumno(30, "Jose Luis", "Saenz", "10.199.666", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Deudor);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Comprueba que se haya instanciado atributo Lista de Jornada
        /// </summary>
        [TestMethod]
        public void InstanciaDeListaJornada()
        {
            Profesor prof = new Profesor();
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, prof);
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Jornada);
        }

    }
}
