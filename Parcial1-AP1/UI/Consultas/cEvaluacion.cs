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

namespace Parcial1_AP1.UI.Consultas
{
    public partial class cEvaluacion : Form
    {
        public cEvaluacion()
        {
            InitializeComponent();
        }

        private void CRegistrodeEvaluacion_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var lista = new List<Evaluacion>();
            if(CriteriotextBox1.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox1.SelectedIndex)
                {
                    case 0:
                        lista = RegistroEvaluacionBLL.GetList(p => true);
                        break;
                    case 1:
                        int id = int.Parse(CriteriotextBox1.Text);
                        lista = RegistroEvaluacionBLL.GetList(p => p.EstudianteId == id);
                        break;
                    case 2:
                        lista = RegistroEvaluacionBLL.GetList(p => p.Nombre.Contains(CriteriotextBox1.Text));
                        break;
                }
                lista = lista.Where(p => p.Fecha.Date >= DesdedateTimePicker1.Value.Date && p.Fecha <= HastadateTimePicker1.Value.Date).ToList();
            }
            else
            {
                lista = RegistroEvaluacionBLL.GetList(p => true);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }
    }
}
