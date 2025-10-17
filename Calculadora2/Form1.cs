using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        //Fase1 : Validar la operación
            string operacionCadena = this.operacionTxT.Text.Trim();

            if (operacionCadena.Length == 0)
{
                MessageBox.Show("Introduce una operación");
                return;
}
            foreach (char c in operacionCadena)
            {
                if (!char.IsDigit(c) && c != '+' && c != '-' && c != '*' && c != '/' && c != '√' && c != '^' && c != '.')
                {
                    MessageBox.Show("ERROR");
                    return;
                }
            }

            char ultimo = operacionCadena[operacionCadena.Length - 1];
            if (ultimo == '+' || ultimo == '-' || ultimo == '*' || ultimo == '/' || ultimo == '√' || ultimo == '^' || ultimo == '.')
            {
                operacionCadena = operacionCadena.Remove(operacionCadena.Length - 1);
            }

        //Fase2: separacion de números y operadores
            List<double> numeros = new List<double>();
            List<char> operadores = new List<char>();

            string operadoresValidos = "+-*/^√"; // lista simple para comprobar operadores
            string numBuffer = "";                 // buffer para construir el número actual

            for (int i = 0; i < operacionCadena.Length; i++)
            {
                char c = operacionCadena[i];

                //El '-' actual es signo (parte del número) en vez de operador??
                bool inicioNumeroNegativo = (c == '-') && (i == 0 || operadoresValidos.Contains(operacionCadena[i - 1]));

                if (inicioNumeroNegativo)
                {
                    // empezamos un número con '-' y avanzamos para leer sus dígitos/decima
                    //    
                    numBuffer = "-";
                    i++; // pasamos al siguiente carácter que debe ser dígito o '.'
                         // recoger la secuencia de dígitos y punto decimal
                    while (i < operacionCadena.Length && (char.IsDigit(operacionCadena[i]) || operacionCadena[i] == '.'))
                    {
                        numBuffer += operacionCadena[i];
                        i++;
                    }
                    // validación rápida: que no sea solo "-" o "-."
                    if (numBuffer == "-" || numBuffer == "-.") throw new Exception("Formato número inválido");
                    // parsear con InvariantCulture (asegura que '.' sea decimal)
                    numeros.Add(double.Parse(numBuffer, CultureInfo.InvariantCulture));
                    numBuffer = "";
                    i--; // ajustar índice porque el for hará i++ al final
                    continue;
                }

                // Si empieza con dígito o punto, recolectamos el número normal
                if (char.IsDigit(c) || c == '.')
                {
                    numBuffer = "";
                    while (i < operacionCadena.Length && (char.IsDigit(operacionCadena[i]) || operacionCadena[i] == '.'))
                    {
                        numBuffer += operacionCadena[i];
                        i++;
                    }
                    // validación simple del número (no solo ".")
                    if (numBuffer == ".") throw new Exception("Formato número inválido");
                    numeros.Add(double.Parse(numBuffer, CultureInfo.InvariantCulture));
                    numBuffer = "";
                    i--; // ajustar índice por el for
                    continue;
                }

                // Si no es número ni signo de negativo, debe ser un operador válido
                if (operadoresValidos.Contains(c))
                {
                    operadores.Add(c);
                }
                else
                {
                    // carácter inesperado (no debería ocurrir si ya validaste antes)
                    throw new Exception($"Carácter inválido en expresión: {c}");
                }
            }

            // Validación final: debe cumplirse numeros.Count == operadores.Count + 1
            if (numeros.Count == 0 || numeros.Count != operadores.Count + 1)
            {
                throw new Exception("Expresión mal formada");
            }












        }


        private void operacionTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btSuma_Click(object sender, EventArgs e)
        {
            int aux = this.operacionTxT.TextLength;
            char signo = this.operacionTxT.Text[aux - 1];

            if (signo != '+' || signo != '-' || signo != '*' || signo != '/' || signo != '√' || signo != '^' || signo != '.')
            {
                operacionTxT.Text += "+";
            }
        }
        
        private void bt0_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "0";
        }

        private void btRaiz_Click(object sender, EventArgs e)
        {
            int aux = this.operacionTxT.TextLength;
            char signo = this.operacionTxT.Text[aux - 1];

            if (signo != '+' || signo != '-' || signo != '*' || signo != '/' || signo != '√' || signo != '^' || signo != '.')
            {
                operacionTxT.Text += "√";
            }
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            operacionTxT.Text += "6";
        }

        private void btComa_Click(object sender, EventArgs e)
        {
            int aux = this.operacionTxT.TextLength;
            char signo = this.operacionTxT.Text[aux - 1];

            if (signo != '+' || signo != '-' || signo != '*' || signo != '/' || signo != '√' || signo != '^' || signo != '.')
            {
                operacionTxT.Text += ".";
            }
        }

        private void btResta_Click(object sender, EventArgs e)
        {
            int aux = this.operacionTxT.TextLength;
            char signo = this.operacionTxT.Text[aux - 1];

            if (signo != '+' || signo != '-' || signo != '*' || signo != '/' || signo != '√' || signo != '^' || signo != '.')
            {
                operacionTxT.Text += "-";
            }
        }

        private void btMultiplicacion_Click(object sender, EventArgs e)
        {
            int aux = this.operacionTxT.TextLength;
            char signo = this.operacionTxT.Text[aux - 1];

            if (signo != '+' || signo != '-' || signo != '*' || signo != '/' || signo != '√' || signo != '^' || signo != '.')
            {
                operacionTxT.Text += "*";
            }
        }

        private void btDivision_Click(object sender, EventArgs e)
        {
            int aux = this.operacionTxT.TextLength;
            char signo = this.operacionTxT.Text[aux - 1];

            if (signo != '+' || signo != '-' || signo != '*' || signo != '/' || signo != '√' || signo != '^' || signo != '.')
            {
                operacionTxT.Text += "/";
            }
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
            int aux = this.operacionTxT.TextLength;
            char signo = this.operacionTxT.Text[aux - 1];

            if (signo != '^')
            {
                operacionTxT.Text += "^";
            }
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

        private void btBorrar_Click(object sender, EventArgs e)
        {
            this.operacionTxT.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
