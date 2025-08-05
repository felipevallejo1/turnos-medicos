using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosMedicos.Core.Models;
public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public int InternalCode { get; set; }

}