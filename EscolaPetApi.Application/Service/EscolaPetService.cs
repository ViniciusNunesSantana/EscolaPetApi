using AutoMapper;
using EscolaPetApi.Application.DTO.Escola;
using EscolaPetApi.Domain.Interface;
using EscolaPetApi.Domain.Models;

namespace EscolaPetApi.Application.Service;
public class EscolaPetService
{
    private readonly IEscolaPet _escola;
    private readonly IMapper _automapper;

    public EscolaPetService(IEscolaPet escola, IMapper automapper)
    {
        _escola = escola;
        _automapper = automapper;
    }

    public async Task<IEnumerable<ReadEscolaPetDTO>> BuscarTodos()
    {
        IEnumerable<EscolaPet> escolas = await _escola.BuscarTodosAsync();

        if (!escolas.Any())
            throw new InvalidOperationException("Lista ainda sem cadastro");

        return _automapper.Map<IEnumerable<ReadEscolaPetDTO>>(escolas);

    }

    public async Task<ReadEscolaPetDTO> BuscarEscolaPorId(int id)
    {
        EscolaPet escola = await _escola.BuscarPorIdAsync(e => e.Id == id);

        if (escola is null)
            throw new InvalidOperationException("Escola pet nao encontrada");

        return _automapper.Map<ReadEscolaPetDTO>(escola);
    }

    public async Task<EscolaPetComTutoresDTO> BuscarEscolaETutor(int id)
    {
        EscolaPet escola = await _escola.BuscarEscolaComtutores(id);

        if (escola is null)
            throw new InvalidOperationException("Escola pet nao encontrada");

        return _automapper.Map<EscolaPetComTutoresDTO>(escola);
    }


    public async Task<CreateEscolaPetDTO> CadastrarEscola(CreateEscolaPetDTO escolaPetDto)
    {
        if (escolaPetDto is null)
            throw new ArgumentNullException("Dados invalidos");

        EscolaPet escola = _automapper.Map<EscolaPet>(escolaPetDto);

        await _escola.AdicionarAsync(escola);

        return _automapper.Map<CreateEscolaPetDTO>(escola);
    }

    public async Task<CreateEscolaPetDTO> AtualizarEscola(CreateEscolaPetDTO escolaPetDto)
    {
        if (escolaPetDto is null)
            throw new ArgumentNullException("Dados invalidos");

        EscolaPet escola = await _escola.BuscarPorIdAsync(e => e.Id == escolaPetDto.Id);

        if (escola is null)
            throw new InvalidOperationException("Escola nao encontrada");

        _automapper.Map(escolaPetDto, escola);

        await _escola.AtualizarAsync(escola);

        return _automapper.Map<CreateEscolaPetDTO>(escola);
    }

    public async Task<bool> ApagarEscola(int id)
    {
        EscolaPet escola = await _escola.BuscarPorIdAsync(e => e.Id == id);

        if (escola is null)
            throw new InvalidOperationException("Escola nao encontrada");

        await _escola.ApagarAsync(escola.Id);

        return true;

    }
}
