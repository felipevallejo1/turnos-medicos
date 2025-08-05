using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnosMedicos.Core.Models;

namespace TurnosMedicos.Core.Interfaces;

public interface IPatientRepository
{
    Task <Patient> AddAsync(Patient patient);
    Task <IEnumerable<Patient>> GetAllAsync();
    Task <Patient?> GetByIdAsync(int id);
    Task <Patient> UpdateAsync (Patient patient);
    Task <bool> DeleteAsync (int id);

}
