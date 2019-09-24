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
            CalificaciontextBox1.Text = string.Empty;
            PuntosperdidostextBox1.Text = string.Empty;
            PronosticocomboBox1.Text = string.Empty;
            Myerror.Clear();
        }
        private Evaluacion LlenaClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.EstudianteId = Convert.ToInt32(EstudianteIdnumericUpDown1.Value);
            evaluacion.Fecha = FechadateTimePicker1.Value;
            evaluacion.Nombre = EstudinatetextBox1.Text;
            evaluacion.Valor = Convert.ToDecimal(ValortextBox1.Text);
            evaluacion.Calificacion = Convert.ToDecimal(CalificaciontextBox1.Text);
            evaluacion.PuntosPerdidos = Convert.ToDecimal(ValortextBox1.Text) - Convert.ToDecimal(CalificaciontextBox1.Text);
            return evaluacion;
        }
        private void LlenaCampo(Evaluacion evaluacion)
        {
            EstudianteIdnumericUpDown1.Value = evaluacion.EstudianteId;
            FechadateTimePicker1.Value = evaluacion.Fecha;
            EstudinatetextBox1.Text = evaluacion.Nombre;
            ValortextBox1.Text = evaluacion.Valor.ToString();
            CalificaciontextBox1.Text = evaluacion.Calificacion.ToString();
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
            if (string.IsNullOrWhiteSpace(CalificaciontextBox1.Text))
            {
                Myerror.SetError(CalificaciontextBox1, "El campo calificacion no puede estar vacio");
                CalificaciontextBox1.Focus();
                paso = false;
            }
            if (PronosticocomboBox1.SelectedIndex == 0)
            {
                Myerror.SetError(PronosticocomboBox1, "El campo pronostico no puede estar vacio");
                PronosticocomboBox1.Focus();
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
            Limpiar();
            Myerror.Clear();
            Evaluacion evaluacion = new Evaluacion();
            int id = Convert.ToInt32(EstudianteIdnumericUpDown1.Value);

            

            if (RegistroEvaluacionBLL.Buscar(id) != null)
            {
                MessageBox.Show("Estudiante encontrado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenaCampo(evaluacion);

            }
            else
            {
                MessageBox.Show("Estudiante no encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            int id = (int)EstudianteIdnumericUpDown1.Value;
            
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
    }
}
