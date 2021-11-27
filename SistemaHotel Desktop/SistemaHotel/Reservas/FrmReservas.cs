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

namespace SistemaHotel.Reservas
{
    public partial class FrmReservas : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;

        string valorQuarto;
        Int32 mes;
        Int32 diasMes;

        double valorTotal;
        double diasReserva;

        string dataPainel;


        string dataInicial;
        string dataFinal;

        string ultimoIdReserva;

        public FrmReservas()
        {
            InitializeComponent();
        }

        private void CarregarCombobox()
        {
            con.AbrirCon();
            sql = "SELECT * FROM quartos order by quarto asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbQuarto.DataSource = dt;
            //cbCargo.ValueMember = "id";
            cbQuarto.DisplayMember = "quarto";

            con.FecharCon();
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Quarto";
            grid.Columns[2].HeaderText = "Data";
           

            grid.Columns[0].Visible = false;
            grid.Columns[3].Visible = false;
            grid.Columns[4].Visible = false;

            //grid.Columns[1].Width = 200;
        }

        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * FROM ocupacoes where id_reserva = @id and funcionario = @funcionario order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", "0");
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }


     


        private void habilitarCampos()
        {
            txtNome.Enabled = true;

            txtValor.Enabled = true;
            cbQuarto.Enabled = true;
            cbMes.Enabled = true;
            cbAno.Enabled = true;
            txtTelefone.Enabled = true;
            btnRemove.Enabled = true;
            txtNome.Focus();

        }


        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtDias.Enabled = false;
            txtValor.Enabled = false;
            cbQuarto.Enabled = false;
            cbMes.Enabled = false;
            cbAno.Enabled = false;
            txtTelefone.Enabled = false;
            btnRemove.Enabled = false;
        }


        private void limparCampos()
        {
            txtNome.Text = "";
            
            txtDias.Text = "0";
            txtTelefone.Text = "";
        }

        private void limparOcupacoes()
        {
            panel1.BackColor = Color.PaleGreen;
            panel1.Enabled = true;

            panel2.BackColor = Color.PaleGreen;
            panel2.Enabled = true;

            panel3.BackColor = Color.PaleGreen;
            panel3.Enabled = true;

            panel4.BackColor = Color.PaleGreen;
            panel4.Enabled = true;

            panel5.BackColor = Color.PaleGreen;
            panel5.Enabled = true;

            panel6.BackColor = Color.PaleGreen;
            panel6.Enabled = true;

            panel7.BackColor = Color.PaleGreen;
            panel7.Enabled = true;

            panel8.BackColor = Color.PaleGreen;
            panel8.Enabled = true;

            panel9.BackColor = Color.PaleGreen;
            panel9.Enabled = true;

            panel10.BackColor = Color.PaleGreen;
            panel10.Enabled = true;

            panel11.BackColor = Color.PaleGreen;
            panel11.Enabled = true;

            panel12.BackColor = Color.PaleGreen;
            panel12.Enabled = true;

            panel13.BackColor = Color.PaleGreen;
            panel13.Enabled = true;

            panel14.BackColor = Color.PaleGreen;
            panel14.Enabled = true;

            panel15.BackColor = Color.PaleGreen;
            panel15.Enabled = true;

            panel16.BackColor = Color.PaleGreen;
            panel16.Enabled = true;

            panel17.BackColor = Color.PaleGreen;
            panel17.Enabled = true;

            panel18.BackColor = Color.PaleGreen;
            panel18.Enabled = true;

            panel19.BackColor = Color.PaleGreen;
            panel19.Enabled = true;

            panel20.BackColor = Color.PaleGreen;
            panel20.Enabled = true;

            panel21.BackColor = Color.PaleGreen;
            panel21.Enabled = true;

            panel22.BackColor = Color.PaleGreen;
            panel22.Enabled = true;

            panel23.BackColor = Color.PaleGreen;
            panel23.Enabled = true;

            panel24.BackColor = Color.PaleGreen;
            panel24.Enabled = true;

            panel25.BackColor = Color.PaleGreen;
            panel25.Enabled = true;

            panel26.BackColor = Color.PaleGreen;
            panel26.Enabled = true;

            panel27.BackColor = Color.PaleGreen;
            panel27.Enabled = true;

            panel28.BackColor = Color.PaleGreen;
            panel28.Enabled = true;

            panel29.BackColor = Color.PaleGreen;
            panel29.Enabled = true;

            panel30.BackColor = Color.PaleGreen;
            panel30.Enabled = true;

            panel31.BackColor = Color.PaleGreen;
            panel31.Enabled = true;

        }

        private void verificarOcupacoes()
        {

            limparOcupacoes();
            string data;
            con.AbrirCon();


            for (int i = 1; i <= diasMes; i += 1)
            {
                if (i < 10)
                {
                              
                        data = 0 + i.ToString() + "/" + cbMes.Text + "/" + cbAno.Text;
                    
                    
                }
                else
                {
                     data = i + "/" + cbMes.Text + "/" + cbAno.Text;
                    
                    
                }

                
                sql = "SELECT * FROM ocupacoes where data = @data and quarto = @quarto";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@quarto", cbQuarto.Text);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();

                if (i == 1 && dt.Rows.Count > 0)
                {
                    panel1.BackColor = Color.Tomato;
                    panel1.Enabled = false;
                }

                if (i == 2 && dt.Rows.Count > 0)
                {
                    panel2.BackColor = Color.Tomato;
                    panel2.Enabled = false;
                }

                if (i == 3 && dt.Rows.Count > 0)
                {
                    panel3.BackColor = Color.Tomato;
                    panel3.Enabled = false;
                }


                if (i == 4 && dt.Rows.Count > 0)
                {
                    panel4.BackColor = Color.Tomato;
                    panel4.Enabled = false;
                }



                if (i == 5 && dt.Rows.Count > 0)
                {
                    panel5.BackColor = Color.Tomato;
                    panel5.Enabled = false;
                }


                if (i == 6 && dt.Rows.Count > 0)
                {
                    panel6.BackColor = Color.Tomato;
                    panel6.Enabled = false;
                }


                if (i == 7 && dt.Rows.Count > 0)
                {
                    panel7.BackColor = Color.Tomato;
                    panel7.Enabled = false;
                }


                if (i == 8 && dt.Rows.Count > 0)
                {
                    panel8.BackColor = Color.Tomato;
                    panel8.Enabled = false;
                }

                if (i == 9 && dt.Rows.Count > 0)
                {
                    panel9.BackColor = Color.Tomato;
                    panel9.Enabled = false;
                }


                if (i == 10 && dt.Rows.Count > 0)
                {
                    panel10.BackColor = Color.Tomato;
                    panel10.Enabled = false;
                }


                if (i == 11 && dt.Rows.Count > 0)
                {
                    panel11.BackColor = Color.Tomato;
                    panel11.Enabled = false;
                }


                if (i == 12 && dt.Rows.Count > 0)
                {
                    panel12.BackColor = Color.Tomato;
                    panel12.Enabled = false;
                }


                if (i == 13 && dt.Rows.Count > 0)
                {
                    panel13.BackColor = Color.Tomato;
                    panel13.Enabled = false;
                }


                if (i == 14 && dt.Rows.Count > 0)
                {
                    panel14.BackColor = Color.Tomato;
                    panel14.Enabled = false;
                }


                if (i == 15 && dt.Rows.Count > 0)
                {
                    panel15.BackColor = Color.Tomato;
                    panel15.Enabled = false;
                }


                if (i == 16 && dt.Rows.Count > 0)
                {
                    panel16.BackColor = Color.Tomato;
                    panel16.Enabled = false;
                }


                if (i == 17 && dt.Rows.Count > 0)
                {
                    panel17.BackColor = Color.Tomato;
                    panel17.Enabled = false;
                }

                if (i == 18 && dt.Rows.Count > 0)
                {
                    panel18.BackColor = Color.Tomato;
                    panel18.Enabled = false;
                }


                if (i == 19 && dt.Rows.Count > 0)
                {
                    panel19.BackColor = Color.Tomato;
                    panel19.Enabled = false;
                }


                if (i == 20 && dt.Rows.Count > 0)
                {
                    panel20.BackColor = Color.Tomato;
                    panel20.Enabled = false;
                }


                if (i == 21 && dt.Rows.Count > 0)
                {
                    panel21.BackColor = Color.Tomato;
                    panel21.Enabled = false;
                }


                if (i == 22 && dt.Rows.Count > 0)
                {
                    panel22.BackColor = Color.Tomato;
                    panel22.Enabled = false;
                }


                if (i == 23 && dt.Rows.Count > 0)
                {
                    panel23.BackColor = Color.Tomato;
                    panel23.Enabled = false;
                }


                if (i == 24 && dt.Rows.Count > 0)
                {
                    panel24.BackColor = Color.Tomato;
                    panel24.Enabled = false;
                }


                if (i == 25 && dt.Rows.Count > 0)
                {
                    panel25.BackColor = Color.Tomato;
                    panel25.Enabled = false;
                }


                if (i == 26 && dt.Rows.Count > 0)
                {
                    panel26.BackColor = Color.Tomato;
                    panel26.Enabled = false;
                }


                if (i == 27 && dt.Rows.Count > 0)
                {
                    panel27.BackColor = Color.Tomato;
                    panel27.Enabled = false;
                }


                if (i == 28 && dt.Rows.Count > 0)
                {
                    panel28.BackColor = Color.Tomato;
                    panel28.Enabled = false;
                }


                if (i == 29 && dt.Rows.Count > 0)
                {
                    panel29.BackColor = Color.Tomato;
                    panel29.Enabled = false;
                }


                if (i == 30 && dt.Rows.Count > 0)
                {
                    panel30.BackColor = Color.Tomato;
                    panel30.Enabled = false;
                }


                if (i == 31 && dt.Rows.Count > 0)
                {
                    panel31.BackColor = Color.Tomato;
                    panel31.Enabled = false;
                }


                

                
            }

            con.FecharCon();

        }



        private void FrmReservas_Load(object sender, EventArgs e)
        {
            
            int mes = DateTime.Now.Month;
            cbMes.Text = mes.ToString();
            int ano = DateTime.Now.Year;
            cbAno.Text = ano.ToString();
            CarregarCombobox();
            cbQuarto.SelectedIndex = 0;
            
            desabilitarCampos();
            Listar();

            verificarDias31();
            verificarOcupacoes();

            
        }

        private void CbQuarto_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT * FROM quartos where quarto = @quarto", con.con);
            cmdVerificar.Parameters.AddWithValue("@quarto", cbQuarto.Text);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    valorQuarto = Convert.ToString(reader["valor"]);

                }

                txtValor.Text = valorQuarto;
            }


            con.FecharCon();

            verificarOcupacoes();
        }

        private void CbMes_SelectedValueChanged(object sender, EventArgs e)
        {

            

        }


        private void verificarDias31()
        {
            
            if (cbMes.Text == "01" || cbMes.Text == "1")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 31;
            }
            if (cbMes.Text == "02" || cbMes.Text == "2")
            {
                panel31.Visible = false;
                panel30.Visible = false;
                panel29.Visible = false;
                diasMes = 28;

                if (cbAno.Text == "2020" || cbAno.Text == "2024" || cbAno.Text == "2028")
                {
                    panel29.Visible = true;
                    diasMes = 29;
                }
            }
            if (cbMes.Text == "03" || cbMes.Text == "3")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 31;
            }
            if (cbMes.Text == "04" || cbMes.Text == "4")
            {
                panel31.Visible = false;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 30;
            }
            if (cbMes.Text == "05" || cbMes.Text == "5")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 31;
            }
            if (cbMes.Text == "06" || cbMes.Text == "6")
            {
                panel31.Visible = false;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 30;
            }
            if (cbMes.Text == "07" || cbMes.Text == "7")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 31;
            }
            if (cbMes.Text == "08" || cbMes.Text == "7")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 31;
            }
            if (cbMes.Text == "09" || cbMes.Text == "9")
            {
                panel31.Visible = false;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 30;
            }
            if (cbMes.Text == "10")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 31;
            }
            if (cbMes.Text == "11")
            {
                panel31.Visible = false;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 30;
            }
            if (cbMes.Text == "12")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                diasMes = 31;
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            if (cbQuarto.Text == "")
            {
                MessageBox.Show("Cadastre Antes um Quarto!");
                Close();
            }

            habilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;


        }

        private void CbAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarDias31();
            verificarOcupacoes();
        }

        private void CbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            mes = Convert.ToInt32(cbMes.Text);
            verificarDias31();

            verificarOcupacoes();
        }

        private void Panel3_Click(object sender, EventArgs e)
        {
            if (mes < 10){
                dataPainel = lbl03.Text + "/0" + cbMes.Text + "/" + cbAno.Text;
                }
            else
            {
                dataPainel = lbl03.Text + "/" + cbMes.Text + "/" + cbAno.Text;
             }
            SalvarOcupacao();

        }

        private void SalvarOcupacao()
        {
            //CÓDIGO DO BOTÃO PARA SALVAR
            con.AbrirCon();
            sql = "INSERT INTO ocupacoes (quarto, data, funcionario) VALUES (@quarto, @data, @funcionario)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@quarto", cbQuarto.Text);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dataPainel));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);


            cmd.ExecuteNonQuery();
            con.FecharCon();
            verificarOcupacoes();
            cbQuarto.Enabled = false;
            Listar();
            AtualizarTotalReserva();


        }

        private void AtualizarTotalReserva()
        {
            diasReserva += 1;
            txtDias.Text = diasReserva.ToString();
            valorTotal = diasReserva * Convert.ToDouble(txtValor.Text);
            lblTotal.Text = string.Format("{0:c2}", valorTotal);
        }

        private void AbaterTotalReserva()
        {
            diasReserva -= 1;
            txtDias.Text = diasReserva.ToString();
            valorTotal = diasReserva * Convert.ToDouble(txtValor.Text);
            lblTotal.Text = string.Format("{0:c2}", valorTotal);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            //CÓDIGO DO BOTÃO PARA EXCLUIR
            con.AbrirCon();
            sql = "DELETE FROM ocupacoes where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.FecharCon();
            verificarOcupacoes();
            AbaterTotalReserva();
            Listar();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRemove.Enabled = true;
            id = grid.CurrentRow.Cells[0].Value.ToString();
        }

        private void Panel2_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl02.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl02.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl01.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl01.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel4_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl04.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl04.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel5_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl05.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl05.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel6_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl06.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl06.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel7_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl07.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl07.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel8_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl08.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl08.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel9_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl09.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl09.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl10_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl10.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl10.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl11_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl11.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl11.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel12_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl12.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl12.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl13_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl13.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl13.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel14_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl14.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl14.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl15_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl15.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl15.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel16_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl16.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl16.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel17_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl17.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl17.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel18_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl18.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl18.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel19_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl19.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl19.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel20_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl20.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl20.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel21_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl21.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl21.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel22_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl22.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl22.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel23_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl23.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl23.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel24_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl24.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl24.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel25_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl25.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl25.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel26_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl26.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl26.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel27_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl27.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl27.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel28_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl28.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl28.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel29_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl29.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl29.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel30_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl30.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl30.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel31_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl31.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl31.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl01_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl01.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl01.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl02_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl02.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl02.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl03_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl03.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl03.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl04_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl04.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl04.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl05_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl05.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl05.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

      
        private void Lbl07_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl07.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl07.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl08_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl08.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl08.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl09_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl09.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl09.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel10_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl10.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl10.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel11_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl11.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl11.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl12_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl12.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl12.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel13_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl13.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl13.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl14_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl14.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl14.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Panel15_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl15.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl15.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl16_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl16.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl16.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl17_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl17.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl17.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl18_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl18.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl18.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl19_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl19.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl19.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl20_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl20.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl20.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl21_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl21.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl21.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl22_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl22.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl22.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl23_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl23.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl23.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl24_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl24.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl24.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl25_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl25.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl25.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl26_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl26.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl26.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl27_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl27.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl27.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl28_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl28.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl28.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl29_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl29.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl29.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl30_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl30.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl30.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl31_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl31.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl31.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void Lbl06_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                dataPainel = lbl06.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            else
            {
                dataPainel = lbl06.Text + "/" + cbMes.Text + "/" + cbAno.Text;
            }
            SalvarOcupacao();
        }

        private void FrmReservas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (valorTotal != 0)
            {
                MessageBox.Show("A reserva possui datas selecionadas, favor remover antes de sair ou salvar a reserva!");
                e.Cancel = true;
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }

            if (valorTotal > 0)
            {

                dataInicial = grid.Rows[0].Cells[2].Value.ToString();
                dataFinal = grid.Rows[grid.Rows.Count - 1].Cells[2].Value.ToString();

                var resultado = MessageBox.Show("Deseja confirmar a reserva nas datas do dia " + Convert.ToDateTime(dataInicial).ToString("dd/MM/yyyy") + " até " + Convert.ToDateTime(dataFinal).ToString("dd/MM/yyyy") + " ?", "Confirmar Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //CÓDIGO DO BOTÃO PARA SALVAR
                    con.AbrirCon();
                    sql = "INSERT INTO reservas (quarto, entrada, saida, dias, valor, nome, telefone, data, funcionario) VALUES (@quarto, @entrada, @saida, @dias, @valor, @nome, @telefone, curDate(), @funcionario)";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@quarto", cbQuarto.Text);
                    cmd.Parameters.AddWithValue("@entrada", Convert.ToDateTime(dataInicial));
                    cmd.Parameters.AddWithValue("@saida", Convert.ToDateTime(dataFinal));
                    cmd.Parameters.AddWithValue("@dias", txtDias.Text);
                    cmd.Parameters.AddWithValue("@valor", valorTotal);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);



                    cmd.ExecuteNonQuery();
                    con.FecharCon();



                    //RECUPERAR O ULTIMA ID DA RESERVA
                    MySqlCommand cmdVerificar;
                    MySqlDataReader reader;
                    con.AbrirCon();
                    cmdVerificar = new MySqlCommand("SELECT id FROM reservas order by id desc LIMIT 1", con.con);

                    reader = cmdVerificar.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                        while (reader.Read())
                        {
                            ultimoIdReserva = Convert.ToString(reader["id"]);




                        }
                    }


                    //RELACIONAR A OCUPACAO COM A RESERVA
                    con.AbrirCon();
                    sql = "UPDATE ocupacoes SET id_reserva = @id_reserva where id_reserva = @id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", "0");
                    cmd.Parameters.AddWithValue("@id_reserva", ultimoIdReserva);


                    cmd.ExecuteNonQuery();
                    con.FecharCon();

                    MessageBox.Show("Reserva efetuada com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNovo.Enabled = true;
                    btnSalvar.Enabled = false;
                    limparCampos();
                    desabilitarCampos();
                    Listar();
                    valorTotal = 0;
                    lblTotal.Text = "0";
                    txtDias.Text = "0";
                    diasReserva = 0;
                }
            }
            else
            {
                MessageBox.Show("A reserva não possui datas!");
            }
            

        }
    }
}
