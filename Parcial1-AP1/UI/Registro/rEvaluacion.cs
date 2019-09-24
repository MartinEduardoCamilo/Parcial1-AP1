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
            EstudianteIdnumericUpDown1.Value = 0;
            FechadateTimePicker1.Value = DateTime.Now;
            EstudinatetextBox1.Text = string.Empty;
            ValortextBox1.Text = string.Empty;
            CalificaciontextBox1.Text = string.Empty;
            PuntosperdidostextBox1.Text = string.Empty;
            PronosticocomboBox1.SelectedItem = 0;
            Myerror.Clear();
        }
        private Evaluacion LlenaClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.EstudianteId = Convert.ToInt32(EstudianteIdnumericUpDown1.Value);
            evaluacion.Fecha = FechadateTimePicker1.Value;
            evaluacion.Estudiante = EstudinatetextBox1.Text;
            evaluacion.Valor = Convert.ToDecimal(ValortextBox1.Text);
            evaluacion.Calificacion = Convert.ToDecimal(CalificaciontextBox1.Text);
            evaluacion.PuntosPerdidos = Convert.ToDecimal(PuntosperdidostextBox1.Text);
            evaluacion.Pronostico = PronosticocomboBox1.SelectedIndex;
            return evaluacion;
        }
        private void LlenaCampo(Evaluacion evaluacion)
        {
            EstudianteIdnumericUpDown1.Value = evaluacion.EstudianteId;
            FechadateTimePicker1.Value = evaluacion.Fecha;
            EstudinatetextBox1.Text = evaluacion.Estudiante;
            ValortextBox1.Text = evaluacion.Valor.ToString();
            CalificaciontextBox1.Text = evaluacion.Calificacion.ToString();
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
            if (string.IsNullOrWhiteSpace(CalificaciontextBox1.Text))
            {
                Myerror.SetError(CalificaciontextBox1, "El campo calificacion no puede estar vacio");
                CalificaciontextBox1.Focus();
                paso = false;
            }
            if (decimal.Parse(ValortextBox1.Text) < 0)
            {
                Myerror.SetError(ValortextBox1, "El campo valor no debe ser negativo");
                ValortextBox1.Focus();
                paso = false;
            }
            if (decimal.Parse(CalificaciontextBox1.Text) < 0)
            {
                Myerror.SetError(CalificaciontextBox1, "El campo calificacion no debe ser negativo");
                CalificaciontextBox1.Focus();
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

        private bool Exite()
        {
            Evaluacion evaluacion = EvaluacionBLL.Buscar((int)EstudianteIdnumericUpDown1.Value);
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
            int.TryParse(EstudianteIdnumericUpDown1.Text, out id);
            evaluacion = EvaluacionBLL.Buscar(id);

            if (evaluacion != null)
            {
                Limpiar();
                LlenaCampo(evaluacion);
            }
            else
            {
                MessageBox.Show("Estudiante no encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardarbutton2_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Evaluacion evaluacion = new Evaluacion();

            if (!Validar())
                return;

            evaluacion = LlenaClase();

            if (EstudianteIdnumericUpDown1.Value == 0)
                paso = EvaluacionBLL.Guardar(evaluacion);
            else
            {
                if (!Exite())
                {
                    MessageBox.Show("estudiante no se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = EvaluacionBLL.Modificar(evaluacion);
            }

            if (paso)
            {
                MessageBox.Show("Se guardo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int.TryParse(EstudianteIdnumericUpDown1.Text, out id);

            if (EvaluacionBLL.Eliminar(id))
            {
                MessageBox.Show("Se elimino correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
        }

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

        private void CalificaciontextBox1_TextChanged(object sender, EventArgs e)
        {
            decimal valor = 0;
            decimal logrado = 0;

            if (!string.IsNullOrWhiteSpace(ValortextBox1.Text))
            {
                valor = Convert.ToDecimal(ValortextBox1.Text);
            }
            if (!string.IsNullOrWhiteSpace(CalificaciontextBox1.Text))
            {
                logrado = Convert.ToDecimal(CalificaciontextBox1.Text);
            }

            decimal perdido = valor - logrado;

            PuntosperdidostextBox1.Text = (valor - logrado).ToString();

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

        private void ValortextBox1_TextChanged(object sender, EventArgs e)
        {

            decimal valor = 0;
            decimal logrado = 0;

            if (!string.IsNullOrWhiteSpace(ValortextBox1.Text))
            {
                valor = Convert.ToDecimal(ValortextBox1.Text);
            }
            if (!string.IsNullOrWhiteSpace(CalificaciontextBox1.Text))
            {
                logrado = Convert.ToDecimal(CalificaciontextBox1.Text);
            }

            decimal perdido = valor - logrado;

            PuntosperdidostextBox1.Text = (valor - logrado).ToString();

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
