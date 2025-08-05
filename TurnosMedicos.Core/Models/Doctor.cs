using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosMedicos.Core.Models;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int SpecialtyId { get; set; }

    public Specialty Specialty { get; set; } = null!;
}
