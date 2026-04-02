using EscolaPetApi.Application.DTO.Tutor;
using EscolaPetApi.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaPetApi.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class TutoresController : ControllerBase
{
    private readonly TutorService _tutorService;

    public TutoresController(TutorService tutorService)
    {
        _tutorService = tutorService;
    }

    [HttpGet]
    public async Task<IActionResult> TodosTutores()
    {
        try
        {
            IEnumerable<ReadTutorDTO> tutor = await _tutorService.BuscarTodosTutores();
            return Ok(tutor);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpGet("com-pet/{id:int}")]
    public async Task<IActionResult> TutorComPet(int id)
    {
        try
        {
            TutorComPetsDTO tutor = await _tutorService.BuscarTutorEPet(id);
            return Ok(tutor);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> TutorPorId(int id)
    {
        try
        {
            ReadTutorDTO tutor = await _tutorService.BuscarTutorPorId(id);
            return Ok(tutor);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarTutor(CreateTutorDTO tutorDto)
    {
        try
        {
            CreateTutorDTO tutor = await _tutorService.AdicionarTutor(tutorDto);
            return Ok(tutor);
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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> AtualizarTutor(int id, CreateTutorDTO tutorDTO)
    {
        tutorDTO.Id = id;

        try
        {
            await _tutorService.AtualizarTutor(tutorDTO);
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
    public async Task<IActionResult> ApagarTutor(int id)
    {
        try
        {
            await _tutorService.ApagarTutor(id);
            return NoContent(); 
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
