using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnosMedicos.Core.Models;

namespace TurnosMedicos.Application.Interfaces;

public interface IPatientService
{
    Task<Patient> AddAsync(Patient patient);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
    Task<Patient?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, Patient patient);
}
