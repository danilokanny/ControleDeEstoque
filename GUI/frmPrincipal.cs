﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Data.SqlClient;

namespace GUI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroCategoria f = new frmCadastroCategoria();
            f.ShowDialog();
            f.Dispose();
        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaCategoria f = new frmConsultaCategoria();
            f.ShowDialog();
            f.Dispose();
        }

        private void subCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroSubCategoria f = new frmCadastroSubCategoria();
            f.ShowDialog();
            f.Dispose();
        }

        private void subCategoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaSubCategoria f = new frmConsultaSubCategoria();
            f.ShowDialog();
            f.Dispose();
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrounidadeDeMedida f = new frmCadastrounidadeDeMedida();
            f.ShowDialog();
            f.Dispose();
        }

        private void unidadeDeMedidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaUnidadeDeMedida f = new frmConsultaUnidadeDeMedida();
            f.ShowDialog();
            f.Dispose();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroProduto f = new frmCadastroProduto();
            f.ShowDialog();
            f.Dispose();
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaProduto f = new frmConsultaProduto();
            f.ShowDialog();
            f.Dispose();
        }

        private void configuraçãoDoBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracaoBancoDados f = new frmConfiguracaoBancoDados();
            f.ShowDialog();
            f.Dispose();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //verifica conexao com o banco
            try
            {
                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.txt");
                DadosDaConexao.servidor = arquivo.ReadLine();
                DadosDaConexao.banco = arquivo.ReadLine();
                DadosDaConexao.usuario = arquivo.ReadLine();
                DadosDaConexao.senha = arquivo.ReadLine();
                arquivo.Close();
                //testar a conexao
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = DadosDaConexao.StringDeConexao;
                conexao.Open();
                conexao.Close();
            }
            catch(SqlException errob)
            {
                MessageBox.Show("Erro ao se conectar no banco de dados \n" +
                                "Acesse as configurações do banco de dados e informe os parâmetros de conexao");
            }
            catch (Exception erros)
            {
                MessageBox.Show(erros.Message);
            }

        }

        private void backupDoBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackupBancoDeDados f = new frmBackupBancoDeDados();
            f.ShowDialog();
            f.Dispose();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroCliente f = new frmCadastroCliente();
            f.ShowDialog();
            f.Dispose();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaCliente f = new frmConsultaCliente();
            f.ShowDialog();
            f.Dispose();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroFornecedor f = new frmCadastroFornecedor();
            f.ShowDialog();
            f.Dispose();
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedor f = new frmConsultaFornecedor();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
