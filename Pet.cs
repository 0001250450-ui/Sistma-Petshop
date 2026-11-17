public class Pet
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Especie { get; set; }
    public string Raca { get; set; }
    public int ClienteId { get; set; } // Regra: Obrigatório associar a um cliente

    public Pet() { }

    public Pet(string nome, string especie, string raca, int clienteId)
    {
        Nome = nome;
        Especie = especie;
        Raca = raca;
        ClienteId = clienteId;
    }
}
