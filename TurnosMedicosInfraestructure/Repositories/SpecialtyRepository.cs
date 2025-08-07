using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnosMedicos.Core.Interfaces;
using TurnosMedicos.Infrastructure.Data;
using TurnosMedicos.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace TurnosMedicos.Infrastructure.Repositories;

public class SpecialtyRepository : ISpecialtyRepository
{
    private readonly ApplicationDbContext _context;

    public SpecialtyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Specialty>> GetAllAsync()
    {
        return await _context.Specialties.ToListAsync();
    }

    public async Task<Specialty?> GetByIdAsync(int id)
    {
        return await _context.Specialties.FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task<Specialty> AddAsync(Specialty specialty)
    {
        await _context.Specialties.AddAsync(specialty);
        await _context.SaveChangesAsync();
        return specialty;
    }

    public async Task<Specialty> UpdateAsync(Specialty specialty)
    {
        _context.Specialties.Update(specialty);
        await _context.SaveChangesAsync();
        return specialty;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var patient = await _context.Specialties.FindAsync(id);
        if (patient == null)
        {
            return false;
        }

        _context.Specialties.Remove(patient);
        await _context.SaveChangesAsync();
        return true;
    }

}
