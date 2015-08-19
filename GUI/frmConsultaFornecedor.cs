using BBL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmConsultaFornecedor : Form
    {
        public int codigo = 0;
        public frmConsultaFornecedor()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLFornecedor bll = new BLLFornecedor(cx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);
        }

        private void frmConsultaFornecedor_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 50;
            dgvDados.Columns[1].HeaderText = "Nome";
            dgvDados.Columns[1].Width = 70;
            dgvDados.Columns[2].HeaderText = "Razão Social";
            dgvDados.Columns[2].Width = 50;
            dgvDados.Columns[3].HeaderText = "Inscrição Estual";
            dgvDados.Columns[3].Width = 50;
            dgvDados.Columns[4].HeaderText = "CPF/CNPJ";
            dgvDados.Columns[4].Width = 90;
            dgvDados.Columns[5].HeaderText = "CEP ";
            dgvDados.Columns[5].Width = 90;
            dgvDados.Columns[6].HeaderText = "Endereço";
            dgvDados.Columns[6].Width = 150;
            dgvDados.Columns[7].HeaderText = "Bairro";
            dgvDados.Columns[7].Width = 60;
            dgvDados.Columns[8].HeaderText = "Telefone";
            dgvDados.Columns[8].Width = 90;
            dgvDados.Columns[9].HeaderText = "Celular";
            dgvDados.Columns[9].Width = 90;
            dgvDados.Columns[10].HeaderText = "E-Mail";
            dgvDados.Columns[10].Width = 150;
            dgvDados.Columns[11].HeaderText = "Numero";
            dgvDados.Columns[11].Width = 10;
            dgvDados.Columns[12].HeaderText = "Cidade";
            dgvDados.Columns[12].Width = 50;
            dgvDados.Columns[13].HeaderText = "Estado";
            dgvDados.Columns[13].Width = 60;
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
