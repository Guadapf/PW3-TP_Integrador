using System;
using System.Collections.Generic;

namespace Nomina;

public partial class Compensacion
{
    public int IdCompensacion { get; set; }

    public int? IdDepartamento { get; set; }

    public decimal? Multiplicador { get; set; }
}
