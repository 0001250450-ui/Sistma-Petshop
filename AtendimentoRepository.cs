using System.Data;
using MySql.Data.MySqlClient;

public class AtendimentoRepository
{
    public void Inserir(Atendimento atendimento)
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = "INSERT INTO atendimentos (pet_id, servico_id, data_atendimento, valor_total) VALUES (@petId, @servicoId, @data, @valor)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@petId", atendimento.PetId);
            comando.Parameters.AddWithValue("@servicoId", atendimento.ServicoId);
            comando.Parameters.AddWithValue("@data", atendimento.DataAtendimento);
            comando.Parameters.AddWithValue("@valor", atendimento.ValorTotal);
            comando.ExecuteNonQuery();
        }
    }

    public DataTable ListarGeral()
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = @"SELECT a.id, p.nome AS pet, s.descricao AS servico, a.data_atendimento, a.valor_total 
                           FROM atendimentos a
                           JOIN pets p ON a.pet_id = p.id
                           JOIN servicos s ON a.servico_id = s.id";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexao);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }
    }
}
