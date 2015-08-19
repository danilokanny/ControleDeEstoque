using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexao
    {
        public static String servidor = "SERVIDOR";
        public static String banco = "ControleDeEstoque";
        public static String usuario = "sa";
        public static String senha = "123456";
        public static String StringDeConexao
        {
            get
            {
                return "Data Source=SERVIDOR;Initial Catalog=ControleDeEstoque;User ID=sa;Password=123456";
            }
        }
    }
}
