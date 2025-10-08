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

        private void btIgual_Click(object sender, EventArgs e)
        {
            string operacionCadena = this.operacionTxT.Text.Replace(" ", "");

            try
            {
    //1-  creo 2 listas, una para los operadoras y otra para los números:

                List<double> numeros = new List<double>();
                List<char> operadores = new List<char>();


                //Bucle para recorrer la cadena IMPORTANSISIMO
                for (int i = 0; i < operacionCadena.Length; i++)
                {

            //2- Detectar negativos antes de una operacion

            //3- Leer números(por los decimales)

            //4- Leer operadores

                    for (int j = 0; j < operadores.Count(); i++)
                        {
                            char op = operacionCadena[i];
                            if (op == '+' || op == '-' || op == '*' || op == '/' || op == '^' || op == '√')
                            {
                                operadores.Add(op);
                                break;
                        }
                    }

            //5- Para procesar multiplicacion y division primero
            //6- Para procesar suma y resta despues                


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }











        }


        private void operacionTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btSuma_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "+";
        }
        
        private void bt0_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "0";
        }

        private void btRaiz_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "√";
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "6";
        }

        private void btComa_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += ".";
        }

        private void btResta_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "-";
        }

        private void btMultiplicacion_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "*";
        }

        private void btDivision_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "/";
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "7";
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "8";
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "9";
        }

        private void btExponente_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "^";
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "4";
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "5";
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "1";
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "2";
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "3";
        }
    }
}
