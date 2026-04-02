using EscolaPetApi.Application.DTO.Escola;
using EscolaPetApi.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace EscolaPetApi.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class EscolaPetsController : ControllerBase
{
    private readonly EscolaPetService _escolaService;

    public EscolaPetsController(EscolaPetService escolaService)
    {
        _escolaService = escolaService;
    }


    [HttpGet]
    public async Task<IActionResult> Lista()
    {
        try
        {
            IEnumerable<ReadEscolaPetDTO> escolas = await _escolaService.BuscarTodos();
            return Ok(escolas);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
      
    }


    [HttpGet("com-tutor/{id:int}")]
    public async Task<IActionResult> EscolaComTutor(int id)
    {
        try
        {
            EscolaPetComTutoresDTO escolaPet = await _escolaService.BuscarEscolaETutor(id);
            return Ok(escolaPet);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> EscolaPorId(int id)
    {
        try
        {
            ReadEscolaPetDTO escola =  await _escolaService.BuscarEscolaPorId(id);
            return Ok(escola);
        }
        catch(InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarEscola(CreateEscolaPetDTO escolaPet)
    {

        try
        {
           CreateEscolaPetDTO escola = await _escolaService.CadastrarEscola(escolaPet);
            return Ok(escola);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> AtualizarEscola(int id,CreateEscolaPetDTO escolaPetDTO)
    {

        escolaPetDTO.Id = id;

        try
        {
            await _escolaService.AtualizarEscola(escolaPetDTO);
            return NoContent();
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> ApagarEscola(int id)
    {
        try
        {
            await _escolaService.ApagarEscola(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
