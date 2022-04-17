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
        /// Realiza operaciones entre dos números.
        /// </summary>
        /// <param name="num1"
        /// <param name="num2"
        /// <param name="operador"></param>
        /// <returns>Resultado de la operación seleccionada</returns>

        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double returnValue;

            switch (ValidarOperador(operador))
            {
                case '+':
                    returnValue = num1 + num2;
                    break;
                case '-':
                    returnValue = num1 - num2;
                    break;
                case '*':
                    returnValue = num1 * num2;
                    break;
                case '/':
                    returnValue = num1 / num2;
                    break;
                default:
                    returnValue = num1 + num2;
                    break;
            }

            return returnValue;
        }

        /// <summary>
        /// Valida que el operador recibido sea válido o retorna "+" en caso contrario.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>El operador recibido o "+" en caso de un operador inválido</returns>
        private static char ValidarOperador(char operador)
        {
            char returnValue;
            
                switch (operador)
                {
                    case '+':
                        returnValue = '+';
                        break;
                    case '-':
                        returnValue = '-';
                        break;
                    case '*':
                        returnValue = '*';
                        break;
                    case '/':
                        returnValue = '/';
                        break;
                    default:
                        returnValue = '+';
                        break;
                }
            return returnValue;
        }
    }
}