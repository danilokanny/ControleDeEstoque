using BBL;
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
    public partial class frmCadastroFornecedor : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroFornecedor()
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
            txtCnpj.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtEstado.Clear();
            txtFone.Clear();
            txtIe.Clear();
            txtEndNumero.Clear();
            txtRsocial.Clear();
        }
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedor f = new frmConsultaFornecedor();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bll = new BLLFornecedor(cx);
                ModeloFornecedor modelo = bll.CarregaModeloFornecedor(f.codigo);
                txtCodigo.Text = modelo.ForCod.ToString();
                txtNome.Text = modelo.ForNome;
                txtCnpj.Text = modelo.ForCnpj;
                txtRsocial.Text = modelo.ForRSocial;
                txtIe.Text = modelo.ForIe;
                txtEndereco.Text = modelo.ForEndereco;
                txtEndNumero.Text = modelo.ForEndNumero;
                txtBairro.Text = modelo.ForBairro;
                txtCep.Text = modelo.ForCep;
                txtCidade.Text = modelo.ForCidade;
                txtEstado.Text = modelo.ForEstado;
                txtEmail.Text = modelo.ForEmail;
                alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
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
                    BLLFornecedor bll = new BLLFornecedor(cx);
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
                ModeloFornecedor modelo = new ModeloFornecedor();
                modelo.ForNome = txtNome.Text;
                modelo.ForCnpj = txtCnpj.Text;
                modelo.ForIe = txtIe.Text;
                modelo.ForRSocial = txtRsocial.Text;
                modelo.ForEndereco = txtEndereco.Text;
                modelo.ForEndNumero = txtEndNumero.Text;
                modelo.ForBairro = txtBairro.Text;
                modelo.ForCep = txtCep.Text;
                modelo.ForCidade = txtCidade.Text;
                modelo.ForEstado = txtEstado.Text;
                modelo.ForFone = txtFone.Text;
                modelo.ForCel = txtCel.Text;
                modelo.ForEmail = txtEmail.Text;
                //obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bll = new BLLFornecedor(cx);
                if (this.operacao == "inserir")
                {
                    //cadastrar uma categoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.ForCod.ToString());

                }
                else
                {
                    //alterar uma categoria
                    modelo.ForCod = Convert.ToInt32(txtCodigo.Text);
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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.alteraBotoes(1);
        }
    }
}
