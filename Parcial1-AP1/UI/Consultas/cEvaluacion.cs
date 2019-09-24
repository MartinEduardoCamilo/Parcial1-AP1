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

        private void Consultabutton1_Click(object sender, EventArgs e)
        {
            var listado = new List<Evaluacion>();
            if(CriteriotextBox1.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox1.SelectedIndex)
                {
                    case 0://todo
                        listado = EvaluacionBLL.GetList(p => true);
                        break;
                    case 1://id
                        int id =Convert.ToInt32(CriteriotextBox1.Text);
                        listado = EvaluacionBLL.GetList(p => p.EstudianteId == id);
                        break;
                    case 2://nombre
                        listado = EvaluacionBLL.GetList(p => p.Estudiante.Contains(CriteriotextBox1.Text));
                        break;
                }
                listado = listado.Where(p => p.Fecha.Date <= DesdedateTimePicker1.Value && p.Fecha.Date >= HastadateTimePicker1.Value).ToList();
            }
            else
            {
                listado = EvaluacionBLL.GetList(p => true);
            }
            ConsultadataGridView1.DataSource = null;
            ConsultadataGridView1.DataSource = listado;
        }
    }
}
