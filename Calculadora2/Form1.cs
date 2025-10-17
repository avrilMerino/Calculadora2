using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculadora2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string expresion = operacion.Text.Replace(" ", "");
            try
            {
                if (string.IsNullOrEmpty(expresion))
                    throw new Exception("Expresión vacía");
 //Listas para números y operadores
                List<double> numeros = new List<double>();
                List<char> operadores = new List<char>();

                int i = 0;

                while (i < expresion.Length)
                {
 //para detectar negativos antes o despues de una op
                    bool esNegativo = false;
                    if (expresion[i] == '-' && (i == 0 || "+-*/".Contains(expresion[i - 1])))
                    {
                        esNegativo = true;
                        i++;
                    }

  //Leer número (posible decimal)
                    string numeroStr = "";
                    while (i < expresion.Length && (char.IsDigit(expresion[i]) || expresion[i] == '.'))
                    {
                        numeroStr += expresion[i];
                        i++;
                    }

                    if (string.IsNullOrEmpty(numeroStr))
                        throw new Exception("Número esperado en la posición " + i);

                    double numero = double.Parse(numeroStr);
                    if (esNegativo) numero = -numero;
                    numeros.Add(numero);

                    //Leer operador
                    if (i < expresion.Length)
                    {
                        char op = expresion[i];
                        if ("+-*/".Contains(op))
                        {
                            operadores.Add(op);
                            i++;
                        }
                        else
                        {
                            throw new Exception("Operador inválido en la posición " + i);
                        }
                    }
                }

                //Procesar multiplicación y división primero
                for (int j = 0; j < operadores.Count; j++)
                {
                    if (operadores[j] == '*' || operadores[j] == '/')
                    {
                        double a = numeros[j];
                        double b = numeros[j + 1];
                        double res = operadores[j] == '*' ? a * b : a / b;

                        numeros[j] = res;
                        numeros.RemoveAt(j + 1);
                        operadores.RemoveAt(j);
                        j--;
                    }
                }

                //Procesar suma y resta
                double resultadoFinal =   numeros[0];
                for (int j = 0; j < operadores.Count; j++)
                {
                    if (operadores[j] == '+') resultadoFinal += numeros[j + 1];
                    else if (operadores[j] == '-') resultadoFinal -= numeros[j + 1];
                }

                textBox2.Text = resultadoFinal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la operación: " + ex.Message);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSuma_Click(object sender, EventArgs e)
        {

        }
        //Aunq le he llamado bt0 se me ha q
        private void bt0_Click(object sender, EventArgs e)
        {

        }

        private void btRaiz_Click(object sender, EventArgs e)
        {

        }

        private void bt6_Click(object sender, EventArgs e)
        {

        }

        private void btComa_Click(object sender, EventArgs e)
        {

        }

        private void btResta_Click(object sender, EventArgs e)
        {

        }

        private void btMultiplicacion_Click(object sender, EventArgs e)
        {

        }

        private void btDivision_Click(object sender, EventArgs e)
        {

        }

        private void bt7_Click(object sender, EventArgs e)
        {

        }

        private void bt8_Click(object sender, EventArgs e)
        {

        }

        private void bt9_Click(object sender, EventArgs e)
        {

        }

        private void btExponente_Click(object sender, EventArgs e)
        {

        }

        private void bt4_Click(object sender, EventArgs e)
        {

        }

        private void bt5_Click(object sender, EventArgs e)
        {

        }

        private void bt1_Click(object sender, EventArgs e)
        {

        }

        private void bt2_Click(object sender, EventArgs e)
        {

        }

        private void bt3_Click(object sender, EventArgs e)
        {

        }
    }
}
