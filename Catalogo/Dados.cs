using MySqlConnector;
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

            string sql = "SELECT Preco FROM Precos " +
                "WHERE idProduto=@id AND idTabela_Preco=@tabela";

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

        public double getPeso(string produto)
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

            double peso = 0;

            string sql = "SELECT Peso FROM Produtos " +
                "WHERE idProduto=@id";

            using MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", produto);

            using MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                peso = Convert.ToDouble(dr["Peso"]);
            }

            return peso;
        } // getPeso()
    }
}
