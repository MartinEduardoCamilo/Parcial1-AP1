using Parcial1_AP1.BLL;
using Parcial1_AP1.Entidades;
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

namespace Parcial1_AP1.UI.Registro
{
    public partial class rEvaluacion : Form
    {
        public rEvaluacion()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            EvaluacionIdnumericUpDown1.Value = 0;
            FechadateTimePicker1.Value = DateTime.Now;
            EstudinatetextBox1.Text = string.Empty;
            ValortextBox1.Text = string.Empty;
            LogradotextBox1.Text = string.Empty;
            PuntosperdidostextBox1.Text = string.Empty;
            PronosticocomboBox1.SelectedItem = 0;
            Myerror.Clear();
        }
        private Evaluacion LlenaClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.Evaluacionid = Convert.ToInt32(EvaluacionIdnumericUpDown1.Value);
            evaluacion.Fecha = FechadateTimePicker1.Value;
            evaluacion.Estudiante = EstudinatetextBox1.Text;
            evaluacion.Valor = Convert.ToDecimal(ValortextBox1.Text);
            evaluacion.Logrado = Convert.ToDecimal(LogradotextBox1.Text);
            evaluacion.PuntosPerdidos = Convert.ToDecimal(PuntosperdidostextBox1.Text);
            evaluacion.Pronostico = PronosticocomboBox1.SelectedIndex;
            return evaluacion;
        }
        private void LlenaCampo(Evaluacion evaluacion)
        {
            EvaluacionIdnumericUpDown1.Value = evaluacion.Evaluacionid;
            FechadateTimePicker1.Value = evaluacion.Fecha;
            EstudinatetextBox1.Text = evaluacion.Estudiante;
            ValortextBox1.Text = evaluacion.Valor.ToString();
            LogradotextBox1.Text = evaluacion.Logrado.ToString();
            PuntosperdidostextBox1.Text = evaluacion.PuntosPerdidos.ToString();
            PronosticocomboBox1.SelectedIndex = evaluacion.Pronostico;
        }

        private bool Validar()
        {
            bool paso = true;
            Myerror.Clear();

            if (string.IsNullOrWhiteSpace(EstudinatetextBox1.Text))
            {
                Myerror.SetError(EstudinatetextBox1, "El campo estudiante no puede estar vacio");
                EstudinatetextBox1.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ValortextBox1.Text))
            {
                Myerror.SetError(ValortextBox1, "El campo valor no puede estar vacio");
                ValortextBox1.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(LogradotextBox1.Text))
            {
                Myerror.SetError(LogradotextBox1, "El campo calificacion no puede estar vacio");
                LogradotextBox1.Focus();
                paso = false;
            }
            if (decimal.Parse(ValortextBox1.Text) < 0)
            {
                Myerror.SetError(ValortextBox1, "El campo valor no debe ser negativo");
                ValortextBox1.Focus();
                paso = false;
            }
            if (decimal.Parse(LogradotextBox1.Text) < 0)
            {
                Myerror.SetError(LogradotextBox1, "El campo calificacion no debe ser negativo");
                LogradotextBox1.Focus();
                paso = false;
            }
            if (decimal.Parse(PuntosperdidostextBox1.Text) < 0)
            {
                Myerror.SetError(PuntosperdidostextBox1, "El campo punto perdidos no debe ser negativo");
                PuntosperdidostextBox1.Focus();
                paso = false;
            }
            return paso;
        }

        private bool Existe()
        {
            Evaluacion evaluacion = EvaluacionBLL.Buscar((int)EvaluacionIdnumericUpDown1.Value);
            return (evaluacion != null);
        }

        private void Nuevobutton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Buscarbutton1_Click(object sender, EventArgs e)
        {
            Myerror.Clear();
            Evaluacion evaluacion = new Evaluacion();
            int id;
            int.TryParse(EvaluacionIdnumericUpDown1.Text, out id);
            evaluacion = EvaluacionBLL.Buscar(id);

            if (evaluacion != null)
            {
                Limpiar();
                LlenaCampo(evaluacion);
            }
            else
            {
                MessageBox.Show("No Encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardarbutton2_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Evaluacion evaluacion = new Evaluacion();

            if (!Validar())
                return;

            evaluacion = LlenaClase();

            if (EvaluacionIdnumericUpDown1.Value == 0)
                paso = EvaluacionBLL.Guardar(evaluacion);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("estudiante no se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = EvaluacionBLL.Modificar(evaluacion);
            }

            if (paso)
            {
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo guardo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton3_Click(object sender, EventArgs e)
        {
            Myerror.Clear();

            int id;
            int.TryParse(EvaluacionIdnumericUpDown1.Text, out id);
            bool paso;



            if (!Existe())
            {
                MessageBox.Show("No se pudo eliminar por que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
                return;
            }

            paso = EvaluacionBLL.Eliminar(id);

            if (paso)
            {
                MessageBox.Show("Se elimino correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // validacion para que no reciba caracteres
        private void ValortextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool paso = false;
            decimal numero = 0;

            for (int i = 0; i < ValortextBox1.Text.Length; i++)
            {
                if (ValortextBox1.Text[i] == '.')
                    paso = true;
                if (paso && numero++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (paso) ? true : false;
            else
                e.Handled = true;
        }

        // validacion para que no reciba caracteres
        private void CalificaciontextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool paso = false;
            decimal numero = 0;

            for (int i = 0; i < ValortextBox1.Text.Length; i++)
            {
                if (ValortextBox1.Text[i] == '.')
                    paso = true;
                if (paso && numero++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (paso) ? true : false;
            else
                e.Handled = true;
        }

        

        private void ValortextBox1_TextChanged(object sender, EventArgs e)
        {

            decimal valor = 0;
            decimal logrado = 0;

            if (!string.IsNullOrWhiteSpace(ValortextBox1.Text))
            {
                valor = Convert.ToDecimal(ValortextBox1.Text, CultureInfo.CreateSpecificCulture("en-US"));
            }
            if (!string.IsNullOrWhiteSpace(LogradotextBox1.Text))
            {
                logrado = Convert.ToDecimal(LogradotextBox1.Text, CultureInfo.CreateSpecificCulture("en-US"));
            }

            decimal perdido = valor - logrado;

            PuntosperdidostextBox1.Text = perdido.ToString();

            if (perdido < 25)
            {
                PronosticocomboBox1.SelectedIndex = 0;
            }
            if (perdido >= 25 && perdido <= 30)
            {
                PronosticocomboBox1.SelectedIndex = 1;
            }
            if (perdido > 30)
            {
                PronosticocomboBox1.SelectedIndex = 2;
            }
        }

        private void LogradotextBox1_TextChanged(object sender, EventArgs e)
        {
            decimal valor = 0;
            decimal logrado = 0;

            if (!string.IsNullOrWhiteSpace(ValortextBox1.Text))
            {
                valor = Convert.ToDecimal(ValortextBox1.Text, CultureInfo.CreateSpecificCulture("en-US"));
            }
            if (!string.IsNullOrWhiteSpace(LogradotextBox1.Text))
            {
                logrado = Convert.ToDecimal(LogradotextBox1.Text,CultureInfo.CreateSpecificCulture("en-US"));
            }

            decimal perdido = valor - logrado;

            PuntosperdidostextBox1.Text = perdido.ToString();

            if (perdido < 25)
            {
                PronosticocomboBox1.SelectedIndex = 0;
            }
            if (perdido >= 25 && perdido <= 30)
            {
                PronosticocomboBox1.SelectedIndex = 1;
            }
            if (perdido > 30)
            {
                PronosticocomboBox1.SelectedIndex = 2;
            }
        }
    }
}
