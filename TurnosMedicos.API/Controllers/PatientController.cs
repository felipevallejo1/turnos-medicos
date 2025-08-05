using Microsoft.AspNetCore.Mvc;
using TurnosMedicos.Application.Interfaces;
using TurnosMedicos.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace TurnosMedicos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<Patient>>>> GetAllPatients()
    {
        var patients = await _patientService.GetAllAsync();

        if (patients == null || !patients.Any())
        {
            return NotFound(new ApiResponse<IEnumerable<Patient>>
            {
                Data = null,
                InternalCode = 400,
                Message = "No hay pacientes para mostrar"
            });
        }

        return Ok(new ApiResponse<IEnumerable<Patient>>
        {
            Data = patients,
            InternalCode = 200,
            Message = "Pacientes obtenidos correctamente"
        });
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<Patient>>> AddPatient([FromBody] Patient patient)
    {
        if (patient == null)
        {
            return BadRequest(new ApiResponse<IEnumerable<Patient>>
            {
                Data = null,
                InternalCode = 400,
                Message = "No se pudo crear el paciente"
            });
        }

        await _patientService.AddAsync(patient);

        return Ok(new ApiResponse<Patient>
        {
            Data = patient,
            InternalCode = 200,
            Message = "Paciente creado correctamente"
        });
    }


    [HttpGet("{id}")] 
    public async Task<ActionResult<ApiResponse<Patient>>> GetPatientById(int id)
    {
        var patient = await _patientService.GetByIdAsync(id);

        if (patient == null)
        {
            return NotFound(new ApiResponse<Patient>
            {
                Data = null,
                InternalCode = 400,
                Message = $"Paciente con id {id} no encontrado"
            });
        }

        return Ok(new ApiResponse<Patient>
        {
            Data = patient,
            InternalCode = 200,
            Message = $"Paciente con id {id} obtenido correctamente: {patient.Name} {patient.LastName}"
        });
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<Patient>>> UpdatePatient(int id, [FromBody] Patient patient)
    {
        var updated = await _patientService.UpdateAsync(id, patient);

        if (!updated)
        {
            return NotFound(new ApiResponse<Patient>
            {
                Data = null,
                InternalCode = 404,
                Message = $"Paciente con id {id} no encontrado"
            });
        }

        return Ok(new ApiResponse<Patient>
        {
            Data = patient,
            InternalCode = 200,
            Message = $"Paciente actualizado correctamente"
        });
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeletePatient(int id)
    {
        var deleted = await _patientService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound(new ApiResponse<bool>
            {
                Data = false,
                InternalCode = 404,
                Message = $"Paciente con id {id} no encontrado"
            });
        }

        return Ok(new ApiResponse<bool>
        {
            Data = true,
            InternalCode = 200,
            Message = $"Paciente con id {id} eliminado correctamente"
        });

    }

}
