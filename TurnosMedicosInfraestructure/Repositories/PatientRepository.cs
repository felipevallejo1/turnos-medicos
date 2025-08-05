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
public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Patient> AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
        return patient;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<Patient?> GetByIdAsync(int id)
    {
        return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Patient> UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
        return patient;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);

        if (patient == null)
        {
            return false;
        }

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
        return true;
    }

}
