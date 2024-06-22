using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entidades;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string? Descripcion { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
