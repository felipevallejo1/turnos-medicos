using Microsoft.AspNetCore.Mvc;
using TurnosMedicos.Application.Interfaces;
using TurnosMedicos.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace TurnosMedicos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecialtyController : ControllerBase
{
    private readonly ISpecialtyService _specialtyService;
    public SpecialtyController(ISpecialtyService specialtyService)
    {
        _specialtyService = specialtyService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<Specialty>>>> GetAllSpecialties()
    {
        var specialties = await _specialtyService.GetAllAsync();

        if (specialties == null || !specialties.Any())
        {
            return NotFound(new ApiResponse<IEnumerable<Specialty>>
            {
                Data = null,
                InternalCode = 400,
                Message = "No hay especialidades para mostrar"
            });
        }

        return Ok(new ApiResponse<IEnumerable<Specialty>>
        {
            Data = specialties,
            InternalCode = 200,
            Message = "Especialidades obtenidos correctamente"
        });
    }


    [HttpPost]
    public async Task<ActionResult<ApiResponse<Specialty>>> AddSpecialty([FromBody] Specialty specialty)
    {
        if (specialty == null)
        {
            return BadRequest(new ApiResponse<IEnumerable<Specialty>>
            {
                Data = null,
                InternalCode = 400,
                Message = "No se pudo crear la especialidad"
            });
        }

        await _specialtyService.AddAsync(specialty);

        return Ok(new ApiResponse<Specialty>
        {
            Data = specialty,
            InternalCode = 200,
            Message = "Especialidad creado correctamente"
        });
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<Specialty>>> GetSpecialtyById(int id)
    {
        var specialty = await _specialtyService.GetByIdAsync(id);

        if (specialty == null)
        {
            return NotFound(new ApiResponse<Specialty>
            {
                Data = null,
                InternalCode = 400,
                Message = $"Especialidad con id {id} no encontrado"
            });
        }

        return Ok(new ApiResponse<Specialty>
        {
            Data = specialty,
            InternalCode = 200,
            Message = $"Paciente con id {id} obtenido correctamente: {specialty.Name}"
        });
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<Patient>>> UpdateSpecialty(int id, [FromBody] Specialty specialty)
    {
        var updated = await _specialtyService.UpdateAsync(id, specialty);

        if (!updated)
        {
            return NotFound(new ApiResponse<Specialty>
            {
                Data = null,
                InternalCode = 404,
                Message = $"Especialidad con id {id} no encontrado"
            });
        }

        return Ok(new ApiResponse<Specialty>
        {
            Data = specialty,
            InternalCode = 200,
            Message = $"Especialidad actualizado correctamente"
        });
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteSpecialty(int id)
    {
        var deleted = await _specialtyService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound(new ApiResponse<bool>
            {
                Data = false,
                InternalCode = 404,
                Message = $"Especialidad con id {id} no encontrada"
            });
        }

        return Ok(new ApiResponse<bool>
        {
            Data = true,
            InternalCode = 200,
            Message = $"Especialidad con id {id} eliminada correctamente"
        });

    }

}
