using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Descuentos
{
    public partial class frmDescuentos : Form
    {
        public frmDescuentos()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtSalarioBruto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error de entrada");
                return;
            }

            if (!rbGerente.Checked && !rbSubgerente.Checked && !rbSecretaria.Checked)
            {
                MessageBox.Show("Por favor, seleccione un tipo de empleado.", "Error de entrada");
                return;
            }

            if (!EsTextoValido(txtNombre.Text) || !EsTextoValido(txtApellido.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre y apellido válidos (solo letras).", "Error de entrada");
                return;
            }

            
            if (!EsNumeroValido(txtSalarioBruto.Text))
            {
                MessageBox.Show("Por favor, ingrese un salario bruto válido (número positivo).", "Error de entrada");
                return;
            }

            
            string nombre = txtNombre.Text;
            string apellidos = txtApellido.Text;
            double salarioBruto = double.Parse(txtSalarioBruto.Text);
            double descuento = 0;
            string tipoEmpleado = "";

            
            if (rbGerente.Checked)
            {
                descuento = salarioBruto * 0.20; 
                tipoEmpleado = "Gerente";
            }
            else if (rbSubgerente.Checked)
            {
                descuento = salarioBruto * 0.15; 
                tipoEmpleado = "Subgerente";
            }
            else if (rbSecretaria.Checked)
            {
                descuento = salarioBruto * 0.05; 
                tipoEmpleado = "Secretaria";
            }

            
            double salarioNeto = salarioBruto - descuento;

            
            txtMonto.Text = descuento.ToString("C2"); 
            txtSalarioNeto.Text = salarioNeto.ToString("C2"); 

            string mensaje = $"Nombre: {nombre} {apellidos}\n";
            mensaje += $"Tipo de empleado: {tipoEmpleado}\n";
            mensaje += $"Salario bruto: {salarioBruto:C2}\n";
            mensaje += $"Descuento: {descuento:C2}\n";
            mensaje += $"Salario neto: {salarioNeto:C2}";

            MessageBox.Show(mensaje, "Resultado del cálculo");
        }

       
        private bool EsTextoValido(string texto)
        {
            return !string.IsNullOrWhiteSpace(texto) && texto.All(char.IsLetter);
        }

        
        private bool EsNumeroValido(string numero)
        {
            return double.TryParse(numero, out double result) && result >= 0;
        }

    }
}

