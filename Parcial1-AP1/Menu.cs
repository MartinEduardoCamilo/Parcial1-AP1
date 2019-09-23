using Parcial1_AP1.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_AP1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void RegitroDeEvaluacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEvaluacion evaluacion = new rEvaluacion();
            evaluacion.MdiParent = this;
            evaluacion.Show();
        }
    }
}
