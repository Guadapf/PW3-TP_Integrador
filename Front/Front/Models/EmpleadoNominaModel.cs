namespace Front.Models;

public class EmpleadoNominaModel
{
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public int Edad { get; set; }
    public int Antiguedad { get; set; }
    public string GeneroDescripcion { get; set; }
    public string PaisDescripcion { get; set; }
    public string DepartamentoDescripcion { get; set; }
    public float Base {  get; set; }
    public float Compensacion { get; set; }
    public float Bono { get; set; }
    public float Total { get; set; }
}