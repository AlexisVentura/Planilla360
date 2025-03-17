using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Agregramos referencias al modelo
using Planilla360.Modelos;
using System.Data.SqlClient;

namespace Planilla360.Pages.Empleados
{
    public class IndexEmpleadosModel : PageModel
    {

        // Definimos las variables para acceder a la configuracion
        private readonly IConfiguration configuracion;

        // Definimos una lista para recorrer nuestros registro de la tabla empleados
        public List<Empleado> listaEmpleados = new List<Empleado>();

        // Constructor
        public IndexEmpleadosModel (IConfiguration configuracion)
        {
            this.configuracion = configuracion;
        }


        public void OnGet()
        {
            try
            {
                // Definimos una variable y le asignamos la cadena de conexion definida en el archivo appsetitings.json
                string cadena = configuracion.GetConnectionString("CadenaConexion");

                // Creamos un objeto de clase SqlConnection indicando como parametro la cadena de conexion
                SqlConnection conexion = new SqlConnection(cadena);

                // Abrimos la conexion
                conexion.Open();

                // Creamos un objeto de la clase SqlCommand para consultar todos los registros de la tabla
                SqlCommand comando = new SqlCommand("select * from Empleados", conexion);

                // Creamos un objeto de la clase SqlDataReader
                SqlDataReader lector = comando.ExecuteReader();

                //Recorremos el DataReader

                while (lector.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.IdEmpleado = lector.GetInt32(0);
                    empleado.Nombre = lector.GetString(1);
                    empleado.Apellido = lector.GetString(2);
                    empleado.CorreoElectronico = lector.GetString(3);
                    empleado.Telefono = lector.GetString(4);
                    empleado.Puesto = lector.GetString(5);
                    empleado.SalarioBase = lector.GetDecimal(6).ToString();
                    empleado.FechaIngreso = lector.GetDateTime(7).ToString();
                    empleado.FechaNacimiento = lector.GetDateTime(8).ToString();
                    empleado.IdPuesto = lector.GetInt32(9);

                    // Agregamos objeto a la lista
                    listaEmpleados.Add(empleado);
                }

                // Cerramos la cadena de Conexion
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
        }
    }
}
