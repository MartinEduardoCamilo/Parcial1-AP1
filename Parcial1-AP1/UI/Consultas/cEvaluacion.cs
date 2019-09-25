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
            var lista = new List<Evaluacion>();

            if(CriteriotextBox1.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox1.SelectedIndex)
                {
                    case 0://todo
                        lista = EvaluacionBLL.GetList(p => true);
                        break;
                    case 1://id
                        int id = Convert.ToInt32(CriteriotextBox1.Text);
                        lista = EvaluacionBLL.GetList(p => p.Evaluacionid == id);
                        break;
                    case 2://nombre
                        lista = EvaluacionBLL.GetList(p => p.Estudiante.Contains(CriteriotextBox1.Text));
                        break;
                }
                lista = lista.Where(p => p.Fecha.Date <= DesdedateTimePicker1.Value && p.Fecha.Date >= HastadateTimePicker1.Value).ToList();
            }
            else
            {
                lista = EvaluacionBLL.GetList(p => true);
            }
            ConsultadataGridView1.DataSource = null;
            ConsultadataGridView1.DataSource = lista;
        }
    }
 }
