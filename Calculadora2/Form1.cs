using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {

                // FASE 1: Lectura y validación básica de la operaciónn
                string operacionCadena = this.operacionTxT.Text.Replace(" ", "");

                if (operacionCadena.Length == 0)
                {
                    MessageBox.Show("Introduce una operación primero.");
                    return;
                }

                foreach (char c in operacionCadena)
                {
                    if (!char.IsDigit(c) && c != '+' && c != '-' && c != '*' &&
                        c != '/' && c != '√' && c != '^' && c != '.')
                    {
                        MessageBox.Show("Símbolo no válido");
                        return;
                    }
                }

                char ultimo = operacionCadena[operacionCadena.Length - 1];
                if ("+-*/^.".Contains(ultimo))
                    operacionCadena = operacionCadena.Remove(operacionCadena.Length - 1);

                //FASE 2: Separación de números y operadores
                List<double> numeros = new List<double>();
                List<char> operadores = new List<char>();
                string operadoresValidos = "+-*/^";
                string numBuffer = "";
                int raizPendiente = 0; // controla cuántas raíces preceden a un número

                for (int i = 0; i < operacionCadena.Length; i++)
                {
                    char c = operacionCadena[i];

                    // Detectar número negativo
                    bool esNegativo = (c == '-') && (i == 0 || "+-*/^".Contains(operacionCadena[i - 1]));
                    if (esNegativo)
                    {
                        numBuffer = "-";
                        i++;
                        if (i >= operacionCadena.Length)
                            throw new Exception("Expresión incompleta después del signo negativo.");
                        c = operacionCadena[i];
                    }

                    // Contar raíces pendientes (no se añaden como operadores binarios)
                    if (c == '√')
                    {
                        raizPendiente++;
                        continue;
                    }

                    // Construir número
                    while (i < operacionCadena.Length && (char.IsDigit(operacionCadena[i]) || operacionCadena[i] == '.'))
                    {
                        numBuffer += operacionCadena[i];
                        i++;
                    }

                    if (numBuffer != "")
                    {
                        if (!double.TryParse(numBuffer, NumberStyles.Float, CultureInfo.InvariantCulture, out double num))
                            throw new Exception("Número no válido: " + numBuffer);

                        // Aplicar raíces pendientes antes de guardar el número
                        for (int r = 0; r < raizPendiente; r++)
                        {
                            if (num < 0)
                                throw new Exception("No se puede calcular la raíz de un número negativo.");
                            num = Math.Sqrt(num);
                        }
                        raizPendiente = 0;

                        numeros.Add(num);
                        numBuffer = "";
                    }

                    // Guardar operadores binarios (+ - * / ^)
                    if (i < operacionCadena.Length && operadoresValidos.Contains(operacionCadena[i]))
                    {
                        operadores.Add(operacionCadena[i]);
                    }
                }

                if (numeros.Count == 0)
                    throw new Exception("Expresión mal formada.");
                if (operadores.Count >= numeros.Count)
                    throw new Exception("Expresión mal formada (falta número).");

                // FASE 3: Procesar potencias (^)
                for (int i = operadores.Count - 1; i >= 0; i--)
                {
                    if (operadores[i] == '^')
                    {
                        double baseNum = numeros[i];
                        double exponente = numeros[i + 1];
                        double resultado = Math.Pow(baseNum, exponente);

                        numeros[i] = resultado;
                        numeros.RemoveAt(i + 1);
                        operadores.RemoveAt(i);
                    }
                }

                // FASE 4: Multiplicaciones (*) y divisiones (/)
                for (int i = 0; i < operadores.Count; i++)
                {
                    if (operadores[i] == '*' || operadores[i] == '/')
                    {
                        double a = numeros[i];
                        double b = numeros[i + 1];
                        double resultado;

                        if (operadores[i] == '*')
                            resultado = a * b;
                        else
                        {
                            if (b == 0)
                                throw new DivideByZeroException();
                            resultado = a / b;
                        }

                        numeros[i] = resultado;
                        numeros.RemoveAt(i + 1);
                        operadores.RemoveAt(i);
                        i--;
                    }
                }

                //FASE 5: Sumas (+) y restas (-)
                double total = numeros[0];
                for (int i = 0; i < operadores.Count; i++)
                {
                    double siguiente = numeros[i + 1];
                    if (operadores[i] == '+')
                        total += siguiente;
                    else if (operadores[i] == '-')
                        total -= siguiente;
                }

                // FASE 6: Mostrar el resultado final
                operacionTxT.Text = total.ToString(CultureInfo.InvariantCulture);
                operacionTxT.Text = total.ToString(CultureInfo.InvariantCulture);
                ParpadearResultado();


            }

            //FASE 7: Manejo de errores
            catch (DivideByZeroException)
            {
                MessageBox.Show("Vuelve a primaria");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        // BLOQUE DE BOTONES: Entrada de números y operadores
        private void AgregarTexto(string texto)
        {
            operacionTxT.AppendText(texto);
        }

        private void AgregarOperador(char operador)
        {
            // Permitir '-' y '√' al inicio
            if (operacionTxT.TextLength == 0)
            {
                if (operador == '-' || operador == '√')
                    operacionTxT.AppendText(operador.ToString());
                return;
            }

            char ultimo = operacionTxT.Text[operacionTxT.TextLength - 1];

            // Permitir '√' después de cualquier operador o número
            if (operador == '√')
            {
                operacionTxT.AppendText(operador.ToString());
                return;
            }

            // Evitar operadores duplicados, excepto cuando el segundo es '-'
            if ("+-*/^.".Contains(ultimo))
            {
                // Permitir secuencia "+-" o "*-" (para negativos después de operadores)
                if (operador == '-' && ultimo != '-')
                    operacionTxT.AppendText(operador.ToString());
                return;
            }

            operacionTxT.AppendText(operador.ToString());
        }


        //BOTONES DE NÚMEROS
        private void bt0_Click(object sender, EventArgs e) => AgregarTexto("0");
        private void bt1_Click(object sender, EventArgs e) => AgregarTexto("1");
        private void bt2_Click(object sender, EventArgs e) => AgregarTexto("2");
        private void bt3_Click(object sender, EventArgs e) => AgregarTexto("3");
        private void bt4_Click(object sender, EventArgs e) => AgregarTexto("4");
        private void bt5_Click(object sender, EventArgs e) => AgregarTexto("5");
        private void bt6_Click(object sender, EventArgs e) => AgregarTexto("6");
        private void bt7_Click(object sender, EventArgs e) => AgregarTexto("7");
        private void bt8_Click(object sender, EventArgs e) => AgregarTexto("8");
        private void bt9_Click(object sender, EventArgs e) => AgregarTexto("9");

        //BOTONES DE OPERADORES
        private void btSuma_Click(object sender, EventArgs e) => AgregarOperador('+');
        private void btResta_Click(object sender, EventArgs e) => AgregarOperador('-');
        private void btMultiplicacion_Click(object sender, EventArgs e) => AgregarOperador('*');
        private void btDivision_Click(object sender, EventArgs e) => AgregarOperador('/');
        private void btRaiz_Click(object sender, EventArgs e) => AgregarOperador('√');
        private void btExponente_Click(object sender, EventArgs e) => AgregarOperador('^');
        private void btComa_Click(object sender, EventArgs e) => AgregarOperador('.');

        //BOTÓN BORRAR
        private void btBorrar_Click(object sender, EventArgs e)
        {
            operacionTxT.Text = "";
        }
        private async void ParpadearResultado()
        {
            Color originalColor = operacionTxT.BackColor;
            int parpadeos = 3; // cantidad de parpadeos
            int intervalo = 150; // milisegundos entre cambios

            for (int i = 0; i < parpadeos; i++)
            {
                operacionTxT.BackColor = Color.LightBlue;
                await Task.Delay(intervalo);
                operacionTxT.BackColor = originalColor;
                await Task.Delay(intervalo);
            }
        }


    }
}
