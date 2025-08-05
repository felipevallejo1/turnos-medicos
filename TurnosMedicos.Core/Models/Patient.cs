namespace TurnosMedicos.Core.Models;
public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int DNI { get; set; }

    public string Email { get; set; }
    public DateTime BirthDate { get; set; }

}
