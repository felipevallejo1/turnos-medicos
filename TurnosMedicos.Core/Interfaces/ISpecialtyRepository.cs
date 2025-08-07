using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnosMedicos.Core.Models;

namespace TurnosMedicos.Core.Interfaces;

public interface ISpecialtyRepository
{
    Task<Specialty> AddAsync(Specialty specialty);
    Task<IEnumerable<Specialty>> GetAllAsync();
    Task<Specialty?> GetByIdAsync(int id);
    Task<Specialty> UpdateAsync(Specialty specialty);
    Task<bool> DeleteAsync(int id);
}
