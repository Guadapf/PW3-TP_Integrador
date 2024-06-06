using System;
using System.Collections.Generic;

namespace Entidades;

public partial class Pai
{
    public int IdPais { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
