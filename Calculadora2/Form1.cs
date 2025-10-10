using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
                // FASE 1: Lectura y validación básica de la operación
                // Limpieza de espacios, verificación de vacíos y eliminación de operadores al final.
                string operacionCadena = this.operacionTxT.Text.Replace(" ", "");

                if (operacionCadena.Length == 0)
                {
                    MessageBox.Show("Introduce una operación primero.");
                    return;
                }

                // Validar caracteres permitidos
                foreach (char c in operacionCadena)
                {
                    if (!char.IsDigit(c) && c != '+' && c != '-' && c != '*' &&
                        c != '/' && c != '√' && c != '^' && c != '.')
                    {
                        MessageBox.Show("Símbolo no válido");
                        return;
                    }
                }

                // Si el último carácter es un operador, se elimina (excepto '√' porque puede preceder)
                char ultimo = operacionCadena[operacionCadena.Length - 1];
                if ("+-*/^.".Contains(ultimo))
                    operacionCadena = operacionCadena.Remove(operacionCadena.Length - 1);

                // FASE 2: Separación de números y operadores
                List<double> numeros = new List<double>();
                List<char> operadores = new List<char>();
                string operadoresValidos = "+-*/^√";
                string numBuffer = "";

                for (int i = 0; i < operacionCadena.Length; i++)
                {
                    char c = operacionCadena[i];

                    // Detectar si '-' pertenece a un número negativo
                    bool esNegativo = (c == '-') && (i == 0 || operadoresValidos.Contains(operacionCadena[i - 1]));
                    if (esNegativo)
                    {
                        numBuffer = "-";
                        i++;
                        if (i >= operacionCadena.Length)
                            throw new Exception("Expresión incompleta después del signo negativo.");
                        c = operacionCadena[i];
                    }

                    // Procesar raíces √
                    if (c == '√')
                    {
                        operadores.Add('√');
                        continue;
                    }

                    // Construir número completo (dígitos y punto decimal)
                    while (i < operacionCadena.Length && (char.IsDigit(operacionCadena[i]) || operacionCadena[i] == '.'))
                    {
                        numBuffer += operacionCadena[i];
                        i++;
                    }

                    // Guardar número si se construyó correctamente
                    if (numBuffer != "")
                    {
                        if (!double.TryParse(numBuffer, NumberStyles.Float, CultureInfo.InvariantCulture, out double num))
                            throw new Exception("Número no válido: " + numBuffer);
                        numeros.Add(num);
                        numBuffer = "";
                    }

                    // Guardar operador si corresponde (menos '√' que ya se trató)
                    if (i < operacionCadena.Length && operadoresValidos.Contains(operacionCadena[i]) && operacionCadena[i] != '√')
                    {
                        operadores.Add(operacionCadena[i]);
                    }
                }

                // Validar coherencia entre números y operadores (ahora más flexible con √)
                if (numeros.Count == 0)
                    throw new Exception("Expresión mal formada.");
                if (operadores.Count > numeros.Count)
                    throw new Exception("Demasiados operadores.");

                // FASE 3: Procesar raíces y potencias
                // √ primero (de izquierda a derecha), ^ después (de derecha a izquierda)

                // Procesar raíces — ahora √ puede estar antes del primer número
                for (int i = 0; i < operadores.Count; i++)
                {
                    if (operadores[i] == '√')
                    {
                        // Si es la primera posición y hay al menos un número, aplica sobre el primero
                        int indiceNumero = (i == 0) ? 0 : i + 1;

                        if (indiceNumero >= numeros.Count)
                            throw new Exception("Raíz sin número válido después.");

                        double valor = numeros[indiceNumero];
                        if (valor < 0)
                            throw new Exception("No se puede calcular la raíz de un número negativo.");

                        double resultado = Math.Sqrt(valor);
                        numeros[indiceNumero] = resultado;
                        operadores.RemoveAt(i);
                        i--;
                    }
                }

                // Procesar potencias (derecha a izquierda)
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

                // FASE 5: Sumas (+) y restas (-)
                double total = numeros[0];
                for (int i = 0; i < operadores.Count; i++)
                {
                    double siguiente = numeros[i + 1];
                    if (operadores[i] == '+')
                        total += siguiente;
                    else if (operadores[i] == '-')
                        total -= siguiente;
                }

                // FASE 6: Mostrar resultado
                operacionTxT.Text = total.ToString(CultureInfo.InvariantCulture);
            }

            // FASE 7: Manejo de errores
            catch (DivideByZeroException)
            {
                MessageBox.Show("Error: División entre cero.");
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
            operacionTxT.AppendText(texto);
        }

        private void AgregarOperador(char operador)
        {
            // Evita operadores duplicados, pero permite '-' o '√' al inicio
            if (operacionTxT.TextLength == 0 && operador != '-' && operador != '√')
                return;

            if (operacionTxT.TextLength > 0)
            {
                char ultimo = operacionTxT.Text[operacionTxT.TextLength - 1];
                if ("+-*/^√.".Contains(ultimo))
                {
                    // Evita secuencias inválidas (excepto casos como √9 o -5)
                    if (!(operador == '-' && ultimo != '-') && operador != '√')
                        return;
                }
            }

            operacionTxT.AppendText(operador.ToString());
        }

        // BOTONES DE NÚMEROS
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

        // BOTONES DE OPERADORES
        private void btSuma_Click(object sender, EventArgs e) => AgregarOperador('+');
        private void btResta_Click(object sender, EventArgs e) => AgregarOperador('-');
        private void btMultiplicacion_Click(object sender, EventArgs e) => AgregarOperador('*');
        private void btDivision_Click(object sender, EventArgs e) => AgregarOperador('/');
        private void btRaiz_Click(object sender, EventArgs e) => AgregarOperador('√');
        private void btExponente_Click(object sender, EventArgs e) => AgregarOperador('^');
        private void btComa_Click(object sender, EventArgs e) => AgregarOperador('.');

        // BOTÓN BORRAR
        private void btBorrar_Click(object sender, EventArgs e)
        {
            operacionTxT.Text = "";
        }
    }
}
