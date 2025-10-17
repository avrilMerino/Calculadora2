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


            try
            {
            
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
