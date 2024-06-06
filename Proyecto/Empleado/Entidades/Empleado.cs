using System;
using System.Collections.Generic;

namespace Entidades;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNac { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public int IdGenero { get; set; }

    public int IdPais { get; set; }

    public int IdDepartamento { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; } = null!;

    public virtual Genero? IdGeneroNavigation { get; set; } = null!;

    public virtual Pai? IdPaisNavigation { get; set; } = null!;
}
