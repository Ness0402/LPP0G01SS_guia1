using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaGeneral
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool EsNumeroValido(string numero)
        {
            return double.TryParse(numero, out _);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNum1.Text) || string.IsNullOrWhiteSpace(txtNum2.Text) || string.IsNullOrWhiteSpace(txtNum3.Text) ||
        !EsNumeroValido(txtNum1.Text) || !EsNumeroValido(txtNum2.Text) || !EsNumeroValido(txtNum3.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos con números válidos.", "Error de entrada");
                return;
            }

            double n1, n2, n3, x1, x2, formula;

            n1 = double.Parse(txtNum1.Text);
            n2 = double.Parse(txtNum2.Text);
            n3 = double.Parse(txtNum3.Text);

            formula = n2 * n2 - 4 * n1 * n3;

            x1 = (-n2 + Math.Sqrt(formula)) / (2 * n1);
            x2 = (-n2 - Math.Sqrt(formula)) / (2 * n1);

            if (formula < 0)
            {
                double parteReal = -n2 / (2 * n1);
                double parteImaginaria = Math.Sqrt(-formula) / (2 * n1);
                txtResultadoX1.Text = $"{Math.Round(parteReal, 2)} + {Math.Round(parteImaginaria, 2)}i";
                txtResultadoX2.Text = $"{Math.Round(parteReal, 2)} - {Math.Round(parteImaginaria, 2)}i";
                return;
            }

            txtResultadoX1.Text = x1.ToString();
            txtResultadoX2.Text = x2.ToString();

        }

        private void txtResultadoX1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtNum1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
