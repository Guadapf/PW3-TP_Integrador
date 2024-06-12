using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

    [JsonIgnore]
    public virtual Departamento? IdDepartamentoNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Genero? IdGeneroNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Pai? IdPaisNavigation { get; set; } = null!;

    [NotMapped]
    public string? DepartamentoDescripcion { get; set; } = null!;
    [NotMapped]
    public string? GeneroDescripcion { get; set; } = null!;
    [NotMapped]
    public string? PaisDescripcion { get; set; } = null!;
}
