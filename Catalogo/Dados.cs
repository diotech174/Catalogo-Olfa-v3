using MySql.Data.MySqlClient;
using System.Collections;

namespace Catalogo
{
    internal class Dados
    {
        private string connectionString = "";

        public Dados()
        {
            string host = Properties.Settings.Default.host;
            string db = Properties.Settings.Default.db;
            string user = Properties.Settings.Default.user;
            string password = Properties.Settings.Default.password;

            connectionString = "Server=" + host + ";Database=" + db + ";User Id=" + user + ";Password=" + password + ";";
        }

        public ArrayList getTabelas()
        {

            using MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Conexão bem-sucedida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro de conexão: {ex.Message}");
            }

            ArrayList tabelas = new ArrayList();

            string sql = "SELECT * FROM Tabela_Precos WHERE Status='A'";
            using MySqlCommand cmd = new MySqlCommand(sql, connection);
            using MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Tabelas t = new Tabelas();
                t.id = dr["idTabela_preco"].ToString();
                t.descricao = dr["Descricao"].ToString();

                tabelas.Add(t);
            }

            return tabelas;
        } // getTabelas()

        public double getPreco(string produto, string tabela)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Conexão bem-sucedida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro de conexão: {ex.Message}");
            }

            double preco = 0;

            string sql = "SELECT pc.Preco FROM Produtos pd " +
                "LEFT JOIN Precos pc ON pc.idFaixa_preco=pd.idFaixa_preco " +
                "WHERE pd.idProduto=@id AND pc.idTabela_Preco=@tabela";

            using MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", produto);
            cmd.Parameters.AddWithValue("@tabela", tabela);

            using MySqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                preco = Convert.ToDouble(dr["Preco"]);
            }

            return preco;
        } // getPreco()
    }
}
