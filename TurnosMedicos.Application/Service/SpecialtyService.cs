using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnosMedicos.Application.Interfaces;
using TurnosMedicos.Infrastructure.Repositories;
using TurnosMedicos.Core.Interfaces;
using TurnosMedicos.Core.Models;


namespace TurnosMedicos.Application.Service;

public class SpecialtyService : ISpecialtyService
{
    private readonly ISpecialtyRepository _specialtyRepository;
    public SpecialtyService(ISpecialtyRepository repository)
    {
        _specialtyRepository = repository;
    }

    public async Task<Specialty> AddAsync(Specialty specialty)
    {
        await _specialtyRepository.AddAsync(specialty);
        return specialty;
    }

    public async Task<IEnumerable<Specialty>> GetAllAsync()
    {
        return await _specialtyRepository.GetAllAsync();
    }

    public async Task<Specialty?> GetByIdAsync(int id)
    {
        return await _specialtyRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(int id, Specialty updatedSpecialty)
    {
        var existingSpecialty = await _specialtyRepository.GetByIdAsync(id);
        if (existingSpecialty == null)
        {
            return false;
        }

        existingSpecialty.Name = updatedSpecialty.Name;

        await _specialtyRepository.UpdateAsync(updatedSpecialty);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var specialty = await _specialtyRepository.GetByIdAsync(id);
        if (specialty == null)
        {
            return false;
        }

        await _specialtyRepository.DeleteAsync(id);
        return true;
    }
}
