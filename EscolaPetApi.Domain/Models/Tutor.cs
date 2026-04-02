using EscolaPetApi.Domain.Interface;

namespace EscolaPetApi.Domain.Models;
public class Tutor : IEntidade
{
    public int Id {  get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public int Idade { get; private set; }
    public string Telefone { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Endereco { get; private set; } = string.Empty;
    public int EscolaId { get; private set; }
    public EscolaPet EscolaPet { get; }

    private List<Pet> _pets = new List<Pet>();
    public IReadOnlyCollection<Pet> Pets => _pets;

    public Tutor(string nome, int idade, string telefone, string email, string endereco, int escolaId)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome invalido", nameof(nome));

        if (idade < 18)
            throw new InvalidOperationException(nameof(idade));

        if (string.IsNullOrWhiteSpace(telefone))
            throw new ArgumentException("Telefone invalido", nameof(telefone));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email invalido", nameof(email));

        if (string.IsNullOrWhiteSpace(endereco))
            throw new ArgumentException("Endereço invalido", nameof(endereco));

        if (escolaId <= 0)
            throw new InvalidOperationException(nameof(escolaId));

        Nome = nome;
        Idade = idade;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
        EscolaId = escolaId;
    }
}
