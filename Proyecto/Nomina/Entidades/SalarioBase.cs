using System;
using System.Collections.Generic;

namespace Nomina;

public partial class SalarioBase
{
    public int IdSalarioBase { get; set; }

    public int? IdPais { get; set; }

    public decimal? Salario { get; set; }
}
