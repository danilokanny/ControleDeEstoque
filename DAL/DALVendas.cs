using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALVendas
    {
         private DALConexao conexao;
        public DALVendas(DALConexao cx)
        {
            this.conexao = cx;
        }
    }
}
