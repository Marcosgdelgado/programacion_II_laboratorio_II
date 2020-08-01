using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
     public class Numero
    {
        /// <summary>
        /// variable privada de tipo double, almacenara 
        /// </summary>
        private double numero;
        /// <summary>
        /// constructo de clase inicializado en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// constructor de clase que almacenara valor asignado
        /// </summary>
        /// <param name="numero"></param> almacenara valor de tipo double
        public Numero(double numero) : this()
        {
            this.numero = numero;
        }
        /// <summary>
        /// Contructor de clase que almacenara valor asignado
        /// </summary>
        /// <param name="strNumero"></param> almacenara valor de tipo string
        public Numero(string strNumero) : this()
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Valida datos ingresados sean numeros.
        /// </summary>
        /// <param name="strNumero"></param> almacena valor ingresado de tipo string
        /// <returns></returns> si el valor ingresado es correcto retorna numero en formato double, si es falso retorna 0
        private double ValidarNumero(string strNumero)
        {
            double numero = 0;

            double.TryParse(strNumero, out numero);

            return numero;
        }
        /// <summary>
        /// Setteado de variable numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }

        }
        /// <summary>
        /// Realiza operacion de suma
        /// </summary>
        /// <param name="num1"></param> Almacena primer operando
        /// <param name="num2"></param> Almacena segundo operando
        /// <returns></returns> resultado de suma entre operandos
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }
        /// <summary>
        /// Realiza operacion de resta
        /// </summary>
        /// <param name="num1"></param> Almacena primer operando
        /// <param name="num2"></param> Almacena segundo operando
        /// <returns></returns> resultado de resta entre operandos
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }
        /// <summary>
        ///  Realiza operacion de multiplicacion
        /// </summary>
        /// <param name="num1"></param> Almacena primer operando
        /// <param name="num2"></param> Almacena segundo operando
        /// <returns></returns> resultado de multipliacion entre operandos
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        /// <summary>
        /// Realiza operacion de division 
        /// </summary>
        /// <param name="num1"></param> Almacena primer operando
        /// <param name="num2"></param> Almacena segundo operando
        /// <returns></returns> Resultado de division entre operandos
        public static double operator /(Numero num1, Numero num2)
        {
            return num1.numero / num2.numero;
        }
        /// <summary>
        /// Convierte numero binario a decimal
        /// </summary>
        /// <param name="numBinario"></param> almacena resultado de operacion en formato binario de tipo string
        /// <returns></returns> Si es correcto devuelve numero en formato decimal de tipo string, caso contrario retorna valor incorrecto
        public static string BinarioDecimal (string numBinario)
        {
            int valor;
            int resultado = 0;
            int potencia = numBinario.Length;

            if (numBinario[0].ToString() != "-" && numBinario != "Valor incorrecto")
            {
                for (int i = 0; i < numBinario.Length; i++)
                {
                    valor = Int32.Parse(numBinario[i].ToString());

                    potencia --;

                    if (valor == 1)
                    {
                        resultado += (int)Math.Pow(2, potencia);
                    }
                    else if (valor> 1)
                    {
                        return numBinario;
                    }
                }
            }
            else
            {
                return "Valor incorrecto";
            }

            return resultado.ToString();
        }
        /// <summary>
        /// Convierte resultado de operacion en decimal a binario
        /// </summary>
        /// <param name="numero"></param> almacena resultado de operacion en formato decimal
        /// <returns></returns> numero binario en formato string
       public static string DecimalBinario (long numero)
        {
            string strNumero;
            

            if (numero >= 0)
            {
                if (numero != 0 && numero != 1)
                {
                    
                    return strNumero = Convert.ToString(numero, 2);

                }
                else
                {
                    return strNumero = Convert.ToString(numero);   
                }
        
            }

            return strNumero = "Valor Incorrecto";

        }
        /// <summary>
        /// valida resultado de operacion pueda ser convertido a binario
        /// </summary>
        /// <param name="numero"></param> almacena resultado de operacion
        /// <returns></returns> numero binario en formato string
        public static string DecimalBinario(string numero)
        {
            long numEntero;
            string strNumero;

            if (numero != "Valor Incorrecto" && numero[0].ToString() != "-")
            {
                numEntero = Convert.ToInt64(numero);
                strNumero = DecimalBinario(numEntero);
            }
            else
            {
                strNumero = "Valor Incorrecto";
            }

            return strNumero;
        }



    }
}
