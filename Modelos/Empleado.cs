namespace Planilla360.Modelos
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public string SalarioBase { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaNacimiento { get; set; }
        public int IdPuesto { get; set; }
    }
}
