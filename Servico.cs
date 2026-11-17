public class Servico
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public Servico() { }

    public Servico(string descricao, decimal preco)
    {
        Descricao = descricao;
        Preco = preco;
    }
}
