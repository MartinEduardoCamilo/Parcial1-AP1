using Parcial1_AP1.BLL;
using Parcial1_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            LogradotextBox1.Text = string.Empty;
            PuntosperdidostextBox1.Text = string.Empty;
            PronosticocomboBox1.SelectedItem = 0;
            Myerror.Clear();
        }
        private Evaluacion LlenaClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.EstudianteId = Convert.ToInt32(EstudianteIdnumericUpDown1.Value);
            evaluacion.Fecha = FechadateTimePicker1.Value;
            evaluacion.Nombre = EstudinatetextBox1.Text;
            evaluacion.Valor = decimal.Parse(ValortextBox1.Text);
            evaluacion.Logrado = decimal.Parse(LogradotextBox1.Text);
            evaluacion.PuntosPerdidos = decimal.Parse(PuntosperdidostextBox1.Text);
            evaluacion.Pronostico = PronosticocomboBox1.SelectedIndex;
            return evaluacion;
        }
        private void LlenaCampo(Evaluacion evaluacion)
        {
            EstudianteIdnumericUpDown1.Value = evaluacion.EstudianteId;
            FechadateTimePicker1.Value = evaluacion.Fecha;
            EstudinatetextBox1.Text = evaluacion.Nombre;
            ValortextBox1.Text = evaluacion.Valor.ToString();
            LogradotextBox1.Text = evaluacion.Logrado.ToString();
            PuntosperdidostextBox1.Text = evaluacion.PuntosPerdidos.ToString();
            PronosticocomboBox1.Text = evaluacion.Pronostico.ToString();
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
            if (PronosticocomboBox1.SelectedIndex == 0)
            {
                Myerror.SetError(PronosticocomboBox1, "El campo pronostico no puede estar vacio");
                PronosticocomboBox1.Focus();
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
            if(decimal.Parse(PuntosperdidostextBox1.Text) < 0)
            {
                Myerror.SetError(PuntosperdidostextBox1, "El campo punto perdidos no debe ser negativo");
                PuntosperdidostextBox1.Focus();
                paso = false;
            }
            return paso;
        }

        private bool Exite()
        {
            Evaluacion evaluacion = RegistroEvaluacionBLL.Buscar((int)EstudianteIdnumericUpDown1.Value);
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
            evaluacion = RegistroEvaluacionBLL.Buscar(id);
            if (evaluacion != null)
            {
                Limpiar();
                MessageBox.Show("Estudiante encontrado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                paso = RegistroEvaluacionBLL.Guardar(evaluacion);
            else
            {
                if (!Exite())
                {
                    MessageBox.Show("estudiante no se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = RegistroEvaluacionBLL.Modificar(evaluacion);
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
            int.TryParse(EstudianteIdnumericUpDown1.Text,out id);
            
            if(RegistroEvaluacionBLL.Eliminar(id))
            {
                MessageBox.Show("Se elimino correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                Myerror.SetError(EstudianteIdnumericUpDown1, "no se puede borrar al alguien que no existe");
                EstudianteIdnumericUpDown1.Focus();
            }
        }

        private void LogradotextBox1_TextChanged(object sender, EventArgs e)
        {

            decimal valor = 0;
            decimal logrado = 0;

            if (ValortextBox1.Text != null)
            {
                valor = decimal.Parse(ValortextBox1.Text);
            }
            if (LogradotextBox1.Text != null)
            {
                logrado = decimal.Parse(LogradotextBox1.Text);
            }

            decimal perdido = valor - logrado;

            PuntosperdidostextBox1.Text = perdido.ToString();

            if (perdido >= 25 && perdido <= 30)
            {
                PronosticocomboBox1.SelectedIndex = 0;
            }
            if (perdido < 25)
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
