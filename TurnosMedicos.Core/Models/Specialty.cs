using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosMedicos.Core.Models;

public class Specialty
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

}
