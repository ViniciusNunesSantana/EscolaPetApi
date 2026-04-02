using EscolaPetApi.Domain.Interface;
using EscolaPetApi.Domain.Models.Enums;
using System;

namespace EscolaPetApi.Domain.Models;
public class Pet : IEntidade
{
    public int Id {  get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public int Idade { get; private set; }
    public Especie Especie { get; private set; }
    public int TutorId { get; private set; }
    public Tutor Tutor { get;}

    public Pet(string nome, int idade, Especie especie, int tutorId)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome invalido", nameof(nome));

        if (idade < 0)
            throw new InvalidOperationException(nameof(idade));

        if(tutorId < 0)
            throw new InvalidOperationException(nameof(tutorId));

        Nome = nome;
        Idade = idade;
        Especie = especie;
        TutorId = tutorId;
    }
}
