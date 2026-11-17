using System.Data;
using MySql.Data.MySqlClient;

public class ClienteRepository
{
    public void Inserir(Cliente cliente)
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = "INSERT INTO clientes (nome, telefone, email) VALUES (@nome, @telefone, @email)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@nome", cliente.Nome);
            comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
            comando.Parameters.AddWithValue("@email", cliente.Email);
            comando.ExecuteNonQuery();
        }
    }

    public DataTable Listar()
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = "SELECT id, nome, telefone, email FROM clientes";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexao);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }
    }
}
