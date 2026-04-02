using EscolaPetApi.Domain.Interface;

namespace EscolaPetApi.Domain.Models;
public class EscolaPet : IEntidade
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Telefone { get; private set; } = string.Empty;
    public string Endereco { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    private List<Tutor> _tutores = new List<Tutor>();
    public IReadOnlyCollection<Tutor> Tutores => _tutores;

    public EscolaPet(string nome, string telefone, string endereco, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome invalido", nameof(nome));

        if (string.IsNullOrWhiteSpace(telefone))
            throw new ArgumentException("Telefone invalido", nameof(telefone));

        if (string.IsNullOrWhiteSpace(endereco))
            throw new ArgumentException("Endereço invalido", nameof(endereco));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email invalido", nameof(email));


        Nome = nome;
        Telefone = telefone;
        Endereco = endereco;
        Email = email;
    }

}
