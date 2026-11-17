using System.Data;
using MySql.Data.MySqlClient;

public class ServicoRepository
{
    public void Inserir(Servico servico)
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = "INSERT INTO servicos (descricao, preco) VALUES (@descricao, @preco)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@descricao", servico.Descricao);
            comando.Parameters.AddWithValue("@preco", servico.Preco);
            comando.ExecuteNonQuery();
        }
    }

    public DataTable Listar()
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = "SELECT id, descricao, preco FROM servicos";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexao);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }
    }
}
