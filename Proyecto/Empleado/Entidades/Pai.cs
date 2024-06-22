using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entidades;

public partial class Pai
{
    public int IdPais { get; set; }

    public string? Descripcion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
