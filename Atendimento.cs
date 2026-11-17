public class Atendimento
{
    public int Id { get; set; }
    public int PetId { get; set; }
    public int ServicoId { get; set; }
    public string DataAtendimento { get; set; }
    public decimal ValorTotal { get; set; }

    public Atendimento() { }

    public Atendimento(int petId, int servicoId, string dataAtendimento, decimal precoServico)
    {
        PetId = petId;
        ServicoId = servicoId;
        DataAtendimento = dataAtendimento;
        ValorTotal = precoServico; // Cálculo automático do valor
    }
}
