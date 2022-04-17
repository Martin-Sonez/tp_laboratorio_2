using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Valida e inicializa un objeto Numero
        /// </summary>
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Realiza la conversion de numero binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>String del numero binario convertido a decimal</returns>
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                return "Valor invalido";
            }
            return Convert.ToInt32(binario, 2).ToString();
        }

        /// <summary>
        /// Valida el decimal y realiza su conversion a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> La conversion del decimal al binario, "Valor invalido" sino se pudo o 0 si el valor era 0 </returns>
        public string DecimalBinario(double numero)
        {
            string cambio = string.Empty;
            int valor = (int)numero;

            if (valor == 0)
                cambio = "0";
            if (valor < 0)
                cambio = "Valor invalido";

            while (valor > 0)
            {
                cambio = valor % 2 + cambio;
                valor = valor / 2;
            }

            return cambio;
        }

        /// <summary>
        /// Valida numero decimal recibido como un string
        /// Asigna -1 si no se pudo realizar la conversion
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>La convercion de un decimal a un numero binario</returns>
        public string DecimalBinario(string numero)
        {

            if (double.TryParse(numero, out double numValidado))
            {
                if (EsBinario(numero))
                {
                    return DecimalBinario(numValidado);
                }
            }
            return DecimalBinario(-1);
        }

        /// <summary>
        /// Valida que el string sea numero binario 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>True si es binario, False si no lo es</returns>

        private static bool EsBinario(string binario)
        {
            bool retorno = false;
            int longBin = binario.Length;
            for (int i = 0; i < longBin; i++)
            {

                if (binario[i] != '1' && binario[i] != '0')
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Constructor de una variable operando. Por defecto este constructor asigna un valor "0" al atributo "numero"
        /// </summary>
        public Operando() : this(0)
        {
            
        }

        /// <summary>
        /// Constructor. Recibe un numero como Double y lo transforma a string para pasarselo al Contructor String
        /// </summary>
        /// <param name="numeroRec"></param>
        public Operando(double numeroRec)
        {
            this.numero = numeroRec;
        }

        /// <summary>
        /// Constructor. Recibe un numero como String, lo valida y lo setea en el campo numero ya convertido a double
        /// Valida que sea un numero valido 
        /// </summary>
        /// <param name="numero"></param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }


        /// <summary>
        /// Sobrecarga el operador "-" para la resta entre dos instancias de tipo numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>La resta entre los atributos numero</returns>
        public static double operator -(Operando num1, Operando num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Sobrecarga el operador "+" para la suma de dos instancias de tipo numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>La suma entre los atributos numero</returns>
        public static double operator +(Operando num1, Operando num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Sobrecarga el operador "*" para la multiplicacion de dos instancias de tipo numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>La multiplicacion entre los atributos numero</returns>
        public static double operator *(Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Sobrecarga el operador "/" para la division de dos instancias de tipo numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>La division entre los atributos numero, o dobule.MinValue en caso que el num2 sea 0</returns>
        public static double operator /(Operando num1, Operando num2)
        {
            if (num2.numero == 0)
                return double.MinValue;
            else
                return num1.numero / num2.numero;
        }

        /// <summary>
        /// Valida que el string sea convertible en un double
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>El string convertido a double o 0, si no pudo realizarse la conversion</returns>
        private double ValidarOperando(string strNumero)
        {
            double.TryParse(strNumero, out double retornar);   
            return retornar;
        }
    }
}
