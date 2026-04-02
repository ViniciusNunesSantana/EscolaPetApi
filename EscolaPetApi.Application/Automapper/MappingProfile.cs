using AutoMapper;
using EscolaPetApi.Application.DTO.Escola;
using EscolaPetApi.Application.DTO.Pet;
using EscolaPetApi.Application.DTO.Tutor;
using EscolaPetApi.Domain.Models;

namespace EscolaPetApi.Application.Automapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EscolaPet, CreateEscolaPetDTO>().ReverseMap();
        CreateMap<EscolaPet, ReadEscolaPetDTO>();
        CreateMap<EscolaPet, EscolaPetComTutoresDTO>();


        CreateMap<Tutor, CreateTutorDTO>().ReverseMap();
        CreateMap<Tutor, ReadTutorDTO>();
        CreateMap<Tutor, TutorComPetsDTO>();

        CreateMap<Pet, CreatePetDTO>().ReverseMap();
        CreateMap<Pet, ReadPetDTO>();

    }
}
