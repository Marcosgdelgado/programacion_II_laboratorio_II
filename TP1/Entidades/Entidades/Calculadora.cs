using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    

    public static class Calculadora
    {
        /// <summary>
        /// Valida operadores ingresados sean correctos
        /// </summary>
        /// <param name="operador"></param> almacenara operador ingresado
        /// <returns></returns> si es correcto retornara el operador ingresado sino retornara operador mas
        private static string ValidarOperador(string operador)
        {
            if (operador == "*" || operador == "-" || operador == "/" || operador == "-")
            {
                return operador;
            }

            return "+";
            
        }
        
        /// <summary>
        /// realizara operaciones entre dos operandos
        /// </summary>
        /// <param name="numeroUno"></param> asignara valor de primer operando ingresado
        /// <param name="numeroDos"></param> asignara valor de segundo operando ingresado
        /// <param name="operador"></param> asignara valor de operador ingresado
        /// <returns></returns> resultado de operacion
        public static double Operar (Numero numeroUno, Numero numeroDos, string operador)
        {
            ValidarOperador(operador);
            
            if (operador == "+")
            {
                return numeroUno + numeroDos;
            }

            if (operador == "-")
            {
                return numeroUno - numeroDos;
            }

            if (operador == "/")
            {
                return numeroUno / numeroDos;
            }

            if (operador == "*")
            {
                return numeroUno * numeroDos;
            }

            return 0;
            
        }

        
    }
}
