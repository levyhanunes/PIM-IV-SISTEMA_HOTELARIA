using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Produtos
{
    public partial class FrmEstoqueBaixo : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
       
        public FrmEstoqueBaixo()
        {
            InitializeComponent();
        }

        private void FrmEstoqueBaixo_Load(object sender, EventArgs e)
        {
            Listar();
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Nome";
            grid.Columns[2].HeaderText = "Descrição";
            grid.Columns[3].HeaderText = "Estoque";
            grid.Columns[4].HeaderText = "Fornecedor";
            grid.Columns[5].HeaderText = "Valor Venda";
            grid.Columns[6].HeaderText = "Valor Compra";
            grid.Columns[7].HeaderText = "Data";
            grid.Columns[8].HeaderText = "Imagem";
            grid.Columns[9].HeaderText = "Id Fornecedor";

            //FORMATAR COLUNA PARA MOEDA
            grid.Columns[5].DefaultCellStyle.Format = "C2";
            grid.Columns[6].DefaultCellStyle.Format = "C2";

            grid.Columns[0].Visible = false;

            grid.Columns[7].Visible = false;
            grid.Columns[8].Visible = false;
            grid.Columns[9].Visible = false;

            grid.Columns[3].Width = 60;
            grid.Columns[5].Width = 90;
            grid.Columns[6].Width = 95;
            grid.Columns[7].Width = 90;
        }

        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT pro.id, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.valor_venda, pro.valor_compra, pro.data, pro.imagem, pro.fornecedor FROM produtos as pro INNER JOIN fornecedores as forn ON pro.fornecedor = forn.id where estoque < @estoque order by pro.nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@estoque", 15);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }

        private void FrmEstoqueBaixo_Activated(object sender, EventArgs e)
        {
            Listar();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.nomeProduto = grid.CurrentRow.Cells[1].Value.ToString();
            Program.estoqueProduto = grid.CurrentRow.Cells[3].Value.ToString();
            Program.valorProduto = grid.CurrentRow.Cells[5].Value.ToString();
            Program.idProduto = grid.CurrentRow.Cells[0].Value.ToString();
            Produtos.FrmEstoque form = new Produtos.FrmEstoque();
            form.Show();
        }
    }
}
