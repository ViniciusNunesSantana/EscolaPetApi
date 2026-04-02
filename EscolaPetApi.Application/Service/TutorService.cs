using AutoMapper;
using EscolaPetApi.Application.DTO.Tutor;
using EscolaPetApi.Domain.Interface;
using EscolaPetApi.Domain.Models;

namespace EscolaPetApi.Application.Service;
public class TutorService
{
    private readonly ITutor _tutor;
    private readonly IMapper _mapper;
    private readonly IEscolaPet _escolaPet;

    public TutorService(ITutor tutor, IMapper mapper, IEscolaPet escolaPet)
    {
        _tutor = tutor;
        _mapper = mapper;
        _escolaPet = escolaPet;
    }

    public async Task<IEnumerable<ReadTutorDTO>> BuscarTodosTutores()
    {
        IEnumerable<Tutor> tutores = await _tutor.BuscarTodosAsync();

        if (!tutores.Any())
            throw new InvalidOperationException("Lista ainda sem cadastro");

        return _mapper.Map<IEnumerable<ReadTutorDTO>>(tutores);
    }

    public async Task<ReadTutorDTO> BuscarTutorPorId(int id)
    {
        Tutor tutor = await _tutor.BuscarPorIdAsync(t => t.Id == id);

        if (tutor is null)
            throw new InvalidOperationException("Tutor nao encontrado");

        return _mapper.Map<ReadTutorDTO>(tutor);
    }

    public async Task<TutorComPetsDTO> BuscarTutorEPet(int id)
    {
        Tutor tutor = await _tutor.BuscarTutorComPets(id);

        if (tutor is null)
            throw new InvalidOperationException("Tutor nao encontrado");

        return _mapper.Map<TutorComPetsDTO>(tutor);
    }

    public async Task<CreateTutorDTO> AdicionarTutor(CreateTutorDTO tutorDTO)
    {
        if (tutorDTO is null)
            throw new ArgumentNullException("Dados invalidos");

        EscolaPet escola = await _escolaPet.BuscarPorIdAsync(e => e.Id == tutorDTO.EscolaId);

        if (escola is null)
            throw new InvalidOperationException("Escola nao encontrada");

        Tutor tutor = _mapper.Map<Tutor>(tutorDTO);

        await _tutor.AdicionarAsync(tutor);

        return _mapper.Map<CreateTutorDTO>(tutor);
    }

    public async Task<CreateTutorDTO> AtualizarTutor(CreateTutorDTO tutorDTO)
    {
        if (tutorDTO is null)
            throw new ArgumentNullException("Dados invalidos");

        Tutor tutor = await _tutor.BuscarPorIdAsync(t => t.Id == tutorDTO.Id);

        if (tutor is null)
            throw new InvalidOperationException("Tutor nao encontrado");

        EscolaPet escola = await _escolaPet.BuscarPorIdAsync(e => e.Id == tutorDTO.EscolaId);

        if (escola is null)
            throw new InvalidOperationException("Escola nao encontrada");

        _mapper.Map(tutorDTO, tutor);

        await _tutor.AtualizarAsync(tutor);

        return _mapper.Map<CreateTutorDTO>(tutor);
    }

    public async Task<bool> ApagarTutor(int id)
    {
        Tutor tutor = await _tutor.BuscarPorIdAsync(t => t.Id == id);

        if (tutor is null)
            throw new InvalidOperationException("Tutor nao encontrado");

        await _tutor.ApagarAsync(tutor.Id);

        return true;
    }
}
