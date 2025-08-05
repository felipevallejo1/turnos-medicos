using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosMedicos.Core.Models;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;


}
