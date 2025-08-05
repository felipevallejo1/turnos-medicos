using TurnosMedicos.Application.Interfaces;
using TurnosMedicos.Infrastructure.Repositories;
using TurnosMedicos.Core.Models;
using TurnosMedicos.Core.Interfaces;

namespace TurnosMedicos.Application.Service;
public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    public PatientService(IPatientRepository repository)
    {
        _patientRepository = repository;
    }

    public async Task<Patient> AddAsync(Patient patient)
    {
        await _patientRepository.AddAsync(patient);
        return patient;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _patientRepository.GetAllAsync();

    }

    public async Task<Patient?> GetByIdAsync(int id)
    {
        return await _patientRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(int id, Patient updatedPatient)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(id);
        if (existingPatient == null)
        {
            return false;
        }

        existingPatient.Name = updatedPatient.Name;
        existingPatient.LastName = updatedPatient.LastName;
        existingPatient.DNI = updatedPatient.DNI;
        existingPatient.Email = updatedPatient.Email;
        existingPatient.BirthDate = updatedPatient.BirthDate;

        await _patientRepository.UpdateAsync(updatedPatient);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        if (patient == null)
        {
            return false;
        }

        await _patientRepository.DeleteAsync(id);
        return true;
    }
}
