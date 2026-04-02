using EscolaPetApi.Application.DTO;
using EscolaPetApi.Application.DTO.Pet;
using EscolaPetApi.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaPetApi.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly PetService _petService;

    public PetsController(PetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public async Task<IActionResult> Lista()
    {
        try
        {
            IEnumerable<CreatePetDTO> pet = await _petService.BuscarTodosPets();
            return Ok(pet);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            CreatePetDTO pet = await _petService.BuscarPetPorId(id);
            return Ok(pet);
        }
        catch (InvalidOperationException ex)
        {
           return NotFound(ex.Message);
        }
    }


    [HttpPost]
    public async Task<IActionResult> AdicionarPet(CreatePetDTO petDTO)
    {
        try
        {
            CreatePetDTO pet = await _petService.AdicionarPet(petDTO);
            return Ok(pet);
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
    public async Task<IActionResult> AtualizarPet(int id, CreatePetDTO petDTO)
    {
        petDTO.Id = id;

        try
        {
            await _petService.AtualizarPet(petDTO);
            return NoContent();
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> ApagarPet(int id)
    {
        try
        {
            await _petService.ApagarPet(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
