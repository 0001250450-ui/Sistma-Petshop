using System.Data;
using MySql.Data.MySqlClient;

public class PetRepository
{
    public void Inserir(Pet pet)
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = "INSERT INTO pets (nome, especie, raca, cliente_id) VALUES (@nome, @especie, @raca, @clienteId)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@nome", pet.Nome);
            comando.Parameters.AddWithValue("@especie", pet.Especie);
            comando.Parameters.AddWithValue("@raca", pet.Raca);
            comando.Parameters.AddWithValue("@clienteId", pet.ClienteId);
            comando.ExecuteNonQuery();
        }
    }

    public DataTable ListarComClientes()
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = @"SELECT p.id, p.nome AS pet, p.especie, p.raca, c.nome AS cliente 
                           FROM pets p 
                           JOIN clientes c ON p.cliente_id = c.id";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexao);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }
    }
}
