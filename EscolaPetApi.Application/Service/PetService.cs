using AutoMapper;
using EscolaPetApi.Application.DTO;
using EscolaPetApi.Application.DTO.Pet;
using EscolaPetApi.Domain.Interface;
using EscolaPetApi.Domain.Models;

namespace EscolaPetApi.Application.Service;
public class PetService
{
    private readonly IRepositorio<Pet> _pet;
    private readonly IMapper _mapper;
    private readonly ITutor _tutor;
    public PetService(IRepositorio<Pet> pet, IMapper mapper, ITutor tutor)
    {
        _pet = pet;
        _mapper = mapper;
        _tutor = tutor;
    }

    public async Task<IEnumerable<CreatePetDTO>> BuscarTodosPets()
    {
        IEnumerable<Pet> pets = await _pet.BuscarTodosAsync();

        if (!pets.Any())
            throw new InvalidOperationException("Lista ainda sem cadastro");

        return _mapper.Map<IEnumerable<CreatePetDTO>>(pets);
    }

    public async Task<CreatePetDTO> BuscarPetPorId(int id)
    {
        Pet pet = await _pet.BuscarPorIdAsync(p => p.Id == id);

        if (pet is null)
            throw new InvalidOperationException("Pet nao encontrado");

        return _mapper.Map<CreatePetDTO>(pet);
    }

    public async Task<CreatePetDTO> AdicionarPet(CreatePetDTO petDTO)
    {
        if (petDTO is null)
            throw new ArgumentNullException("Dados invalidos");

        Tutor tutor = await _tutor.BuscarPorIdAsync(t => t.Id == petDTO.TutorId);

        if (tutor is null)
            throw new InvalidOperationException("Tutor nao encontrado");

        Pet pet = _mapper.Map<Pet>(petDTO);

        await _pet.AdicionarAsync(pet);

        return _mapper.Map<CreatePetDTO>(pet);
    }

    public async Task<CreatePetDTO> AtualizarPet(CreatePetDTO petDTO)
    {
        if (petDTO is null)
            throw new ArgumentNullException("Dados invalidos");

        Pet pet = await _pet.BuscarPorIdAsync(p => p.Id == petDTO.Id);

        if (pet is null)
            throw new InvalidOperationException("Pet nao encontrado");

        Tutor tutor = await _tutor.BuscarPorIdAsync(t => t.Id == petDTO.TutorId);

        if (tutor is null)
            throw new InvalidOperationException("Tutor nao encontrado");


        _mapper.Map(petDTO, pet);

       await _pet.AtualizarAsync(pet);

        return _mapper.Map<CreatePetDTO>(pet);
    }

    public async Task<bool> ApagarPet(int id)
    {
        Pet pet = await _pet.BuscarPorIdAsync(p => p.Id == id);

        if (pet is null)
            throw new InvalidOperationException("Pet nao encontrado");

        await _pet.ApagarAsync(pet.Id);

        return true;
    }
}
