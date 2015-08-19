using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class BLLCliente
    {
        private DALConexao conexao;
        public BLLCliente(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCliente modelo)
        {
            if (modelo.CliNome.Trim().Length == 0)
            {
                throw new Exception("O nome do Cliente é obrigatório");
            }
            if (modelo.CliCidade.Trim().Length == 0)
            {
                throw new Exception("O nome da Cidade é obrigatório");
            }
            if (modelo.CliEstado.Trim().Length == 0)
            {
                throw new Exception("O nome do estado é obrigatório");
            }

            DALCliente DALobj = new DALCliente(conexao);
            DALobj.Incluir(modelo);
        }

        public void Excluir(int codigo)
        {
            DALCliente DALobj = new DALCliente(conexao);
            DALobj.Excluir(codigo);
        }

        public void Alterar(ModeloCliente modelo)
        {
            if (modelo.CliNome.Trim().Length == 0)
            {
                throw new Exception("O nome do Cliente é obrigatório");
            }
            if (modelo.CliCidade.Trim().Length == 0)
            {
                throw new Exception("O nome da Cidade é obrigatório");
            }
            if (modelo.CliEstado.Trim().Length == 0)
            {
                throw new Exception("O nome do estado é obrigatório");
            }
            //modelo.CatNome = modelo.CatNome.ToUpper();

            DALCliente DALobj = new DALCliente(conexao);
            DALobj.Alterar(modelo);
        }

        public DataTable Localizar(String valor)
        {
            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloCliente CarregaModeloCliente(int codigo)
        {
            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.CarregaModeloCliente(codigo);
        }
    }
}
