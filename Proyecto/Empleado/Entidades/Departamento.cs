using System;
using System.Collections.Generic;

namespace Entidades;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? Descripcion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
