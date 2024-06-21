﻿namespace Front.Models;

public class EmpleadoModel
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNac { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public int IdGenero { get; set; }

    public int IdPais { get; set; }

    public int IdDepartamento { get; set; }
}
