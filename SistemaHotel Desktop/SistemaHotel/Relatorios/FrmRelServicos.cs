using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRelServicos : Form
    {
        public FrmRelServicos()
        {
            InitializeComponent();
        }

        private void FrmRelServicos_Load(object sender, EventArgs e)
        {
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            BuscarPorData();
        }


        private void BuscarPorData()
        {
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarPorData();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarPorData();
        }
    }
}
