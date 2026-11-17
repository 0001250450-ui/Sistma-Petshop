using MySql.Data.MySqlClient;

public class Conexao
{
    private string stringConexao = "server=localhost;database=petshop;uid=root;pwd=;";

    public MySqlConnection Conectar()
    {
        MySqlConnection conexao = new MySqlConnection(stringConexao);
        return conexao;
    }
}
