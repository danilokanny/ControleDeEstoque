using BBL;
using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroCliente : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroCliente()
        {
            InitializeComponent();
        }
        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtBairro.Clear();
            txtCel.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            txtCpfCnpj.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtEstado.Clear();
            txtFone.Clear();
            txtIe.Clear();
            txtTipo.Clear();
            txtEndNumero.Clear();
            txtRsocial.Clear();
        }
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.alteraBotoes(1);
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
             try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLCliente bll = new BLLCliente(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.LimpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro esta sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados
                ModeloCliente modelo = new ModeloCliente();
                modelo.CliNome = txtNome.Text;
                modelo.CliCpfCnpj = txtCpfCnpj.Text;
                modelo.CliRgie = txtIe.Text;
                modelo.CliRSocial = txtRsocial.Text;
                modelo.CliEndereco = txtEndereco.Text;
                modelo.CliEndNumero = txtEndNumero.Text;
                modelo.CliBairro = txtBairro.Text;
                modelo.CliCep = txtCep.Text;
                modelo.CliCidade = txtCidade.Text;
                modelo.CliEstado = txtEstado.Text;
                modelo.CliFone = txtFone.Text;
                modelo.CliCel = txtCel.Text;
                modelo.CliEmail = txtEmail.Text;
                modelo.CliTipo = Convert.ToInt32(txtTipo.Text);
                //obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCliente bll = new BLLCliente(cx);
                if (this.operacao == "inserir")
                {
                    //cadastrar uma categoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.CliCod.ToString());

                }
                else
                {
                    //alterar uma categoria
                    modelo.CliCod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado");
                }
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaCliente f = new frmConsultaCliente();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCliente bll = new BLLCliente(cx);
                ModeloCliente modelo = bll.CarregaModeloCliente(f.codigo);
                txtCodigo.Text = modelo.CliCod.ToString();
                txtNome.Text = modelo.CliNome;
                txtCpfCnpj.Text = modelo.CliCpfCnpj;
                txtRsocial.Text = modelo.CliRSocial;
                txtIe.Text = modelo.CliRgie;
                txtEndereco.Text = modelo.CliEndereco;
                txtEndNumero.Text = modelo.CliEndNumero;
                txtBairro.Text = modelo.CliBairro;
                txtCep.Text = modelo.CliCep;
                txtCidade.Text = modelo.CliCidade;
                txtEstado.Text = modelo.CliEstado;
                txtEmail.Text = modelo.CliEmail;
                txtTipo.Text = modelo.CliTipo;
                alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
        }

    }
}
