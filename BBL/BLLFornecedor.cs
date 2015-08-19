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
    public class BLLFornecedor
    {
        private DALConexao conexao;
        public BLLFornecedor(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloFornecedor modelo)
        {
            if (modelo.ForNome.Trim().Length == 0)
            {
                throw new Exception("O nome do Fornecedor é obrigatório");
            }
            if (modelo.ForRSocial.Trim().Length == 0)
            {
                throw new Exception("O nome da Rasão Social (Nome do Local) é obrigatório");
            }
            if (modelo.ForCidade.Trim().Length == 0)
            {
                throw new Exception("O nome da Cidade é obrigatório");
            }
            if (modelo.ForEstado.Trim().Length == 0)
            {
                throw new Exception("O nome do estado é obrigatório");
            }

            DALFornecedor DALobj = new DALFornecedor(conexao);
            DALobj.Incluir(modelo);
        }

        public void Excluir(int codigo)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            DALobj.Excluir(codigo);
        }

        public void Alterar(ModeloFornecedor modelo)
        {
            if (modelo.ForNome.Trim().Length == 0)
            {
                throw new Exception("O nome do Cliente é obrigatório");
            }
            if (modelo.ForRSocial.Trim().Length == 0)
            {
                throw new Exception("O nome da Rasão Social (Nome do Local) é obrigatório");
            }
            if (modelo.ForCidade.Trim().Length == 0)
            {
                throw new Exception("O nome da Cidade é obrigatório");
            }
            if (modelo.ForEstado.Trim().Length == 0)
            {
                throw new Exception("O nome do estado é obrigatório");
            }
            //modelo.CatNome = modelo.CatNome.ToUpper();

            DALFornecedor DALobj = new DALFornecedor(conexao);
            DALobj.Alterar(modelo);
        }

        public DataTable Localizar(String valor)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloFornecedor CarregaModeloFornecedor(int codigo)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.CarregaModeloFornecedor(codigo);
        }
    }
}
