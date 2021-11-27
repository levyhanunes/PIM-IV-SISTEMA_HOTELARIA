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
    public partial class FrmMovimentacoesGerais : Form
    {
        public FrmMovimentacoesGerais()
        {
            InitializeComponent();
        }

        private void FrmMovimentacoesGerais_Load(object sender, EventArgs e)
        {

            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            
            BuscarData();
        }


        private void BuscarData()
        {
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
