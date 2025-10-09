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
            try
            {
                
// FASE 1: Lectura y validación básica de la operaciónn
                // Aquí limpiamos la cadena de espacios, revisamos que no esté vacía
                // y eliminamos errores típicos como operadores al final.

                string operacionCadena = this.operacionTxT.Text.Replace(" ", "");

                if (operacionCadena.Length == 0)
                {
                    MessageBox.Show("Introduce una operación primero.");
                    return;
                }

                // Revisamos que solo contenga dígitos o símbolos permitidos
                foreach (char c in operacionCadena)
                {
                    if (!char.IsDigit(c) && c != '+' && c != '-' && c != '*' &&
                        c != '/' && c != '√' && c != '^' && c != '.')
                    {
                        MessageBox.Show("Símbolo no permitido en la operación.");
                        return;
                    }
                }

                // Si el último carácter es un operador, lo quitamos
                char ultimo = operacionCadena[operacionCadena.Length - 1];
                if ("+-*/^√.".Contains(ultimo))
                    operacionCadena = operacionCadena.Remove(operacionCadena.Length - 1);

//FASE 2: Separación de números y operadores
                // Aquí recorremos la cadena carácter a carácter.
                // Vamos construyendo números (incluso con decimales)
                // y guardamos los operadores encontrados en otra lista.

                List<double> numeros = new List<double>();
                List<char> operadores = new List<char>();
                string operadoresValidos = "+-*/^√";
                string numBuffer = "";

                for (int i = 0; i < operacionCadena.Length; i++)
                {
                    char c = operacionCadena[i];

                    // Detectar si el '-' es parte de un número negativo
                    bool esNegativo = (c == '-') && (i == 0 || operadoresValidos.Contains(operacionCadena[i - 1]));
                    if (esNegativo)
                    {
                        numBuffer = "-";
                        i++;
                    }

                    // Construimos el número completo (puede tener varios dígitos o '.')
                    while (i < operacionCadena.Length && (char.IsDigit(operacionCadena[i]) || operacionCadena[i] == '.'))
                    {
                        numBuffer += operacionCadena[i];
                        i++;
                    }

                    // Si hemos construido un número, lo guardamos
                    if (numBuffer != "")
                    {
                        numeros.Add(double.Parse(numBuffer, CultureInfo.InvariantCulture));
                        numBuffer = "";
                    }

                    // Si el carácter actual es operador, lo guardamos
                    if (i < operacionCadena.Length && operadoresValidos.Contains(operacionCadena[i]))
                    {
                        operadores.Add(operacionCadena[i]);
                    }
                }

                // Validamos que la cantidad de números y operadores tenga sentido
                if (numeros.Count == 0 || numeros.Count != operadores.Count + 1)
                    throw new Exception("Expresión mal formada.");


// FASE 3: Procesar raíces (√) y potencias (^)
                // Se hacen antes que multiplicar o dividir (prioridad matemática).
                // √ actúa sobre el número siguiente. ^ usa el actual y el siguiente.

                for (int i = 0; i < operadores.Count; i++)
                {
                    if (operadores[i] == '√')
                    {
                        double valor = numeros[i + 1];
                        if (valor < 0)
                            throw new Exception("No se puede calcular la raíz de un número negativo.");

                        double resultado = Math.Sqrt(valor);
                        numeros[i + 1] = resultado;
                        operadores.RemoveAt(i);
                        i--;
                    }
                    else if (operadores[i] == '^')
                    {
                        double baseNum = numeros[i];
                        double exponente = numeros[i + 1];
                        double resultado = Math.Pow(baseNum, exponente);

                        numeros[i] = resultado;
                        numeros.RemoveAt(i + 1);
                        operadores.RemoveAt(i);
                        i--;
                    }
                }

// FASE 4: Procesar multiplicaciones (*) y divisiones (/)
                // Recorremos operadores de izquierda a derecha.
                // Cada vez que hay * o /, calculamos y reemplazamos los números.
                for (int i = 0; i < operadores.Count; i++)
                {
                    if (operadores[i] == '*' || operadores[i] == '/')
                    {
                        double a = numeros[i];
                        double b = numeros[i + 1];
                        double resultado = 0;

                        if (operadores[i] == '*')
                            resultado = a * b;
                        else
                        {
                            if (b == 0) throw new DivideByZeroException();
                            resultado = a / b;
                        }

                        // Guardamos el resultado y eliminamos los usados
                        numeros[i] = resultado;
                        numeros.RemoveAt(i + 1);
                        operadores.RemoveAt(i);
                        i--;
                    }
                }

//FASE 5: Procesar sumas (+) y restas (-)
                // Ya solo quedan sumas y restas.
                // Vamos recorriendo y acumulando el resultado total.
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
                // Mostramos el total directamente en la caja de texto.
                // ToString con InvariantCulture para mantener el punto decimal.
                operacionTxT.Text = total.ToString(CultureInfo.InvariantCulture);
            }

//FASE 7: Manejo de errores
            // Mostramos mensajes claros si ocurre algo.
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
            // Añade un número u operador al final del texto actual
            operacionTxT.Text += texto;
        }

        private void AgregarOperador(char operador)
        {
            // Evita que se añadan dos operadores seguidos (como "5++" o "6**")
            if (operacionTxT.TextLength == 0) return; // No puede empezar con operador (excepto '-')
            char ultimo = operacionTxT.Text.Last();

            string operadores = "+-*/√^.";
            if (!operadores.Contains(ultimo))
            {
                operacionTxT.Text += operador;
            }
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

        private void operacionTxt_TextChanged(object sender, EventArgs e)
{
            //evita que el diseñador falle  vete tu a saber por qué
        }

    }
}
