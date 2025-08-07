using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnosMedicos.Core.Models;

namespace TurnosMedicos.Application.Interfaces;
public interface ISpecialtyService
{
    Task<Specialty> AddAsync(Specialty specialty);
    Task<IEnumerable<Specialty>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
    Task<Specialty?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, Specialty specialty);
}
