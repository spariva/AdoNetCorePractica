using AdoNetCorePractica.Helpers;
using AdoNetCorePractica.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetCorePractica.Repositories
{
    public class RepositoryEmpleadosDepartamentos
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader; 

        public RepositoryEmpleadosDepartamentos()
        {
            string connectionString = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetDepartamentosAsync()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> departamentos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return departamentos;
        }

        public async Task<DatosDepartamentos> GetDatosDepartamentosAsync(string nombre)
        {
            string sql = "SP_DATOS_DEPARTAMENTOS";
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            DatosDepartamentos departamento = new DatosDepartamentos();
            while (await this.reader.ReadAsync())
            {
                int id = int.Parse(this.reader["DEPT_NO"].ToString());
                string dnombre = this.reader["DNOMBRE"].ToString();
                string localidad = this.reader["LOC"].ToString();
                departamento.IdDepartamento = id;
                departamento.Nombre = dnombre;
                departamento.Localidad = localidad;
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return departamento;
        }

        public async Task<List<EmpleadosDepartamentos>> GetEmpleadosDepartamentoAsync(string nombreDepartamento)
        {
            string sql = "select EMP.* from EMP inner join DEPT on EMP.DEPT_NO = DEPT.DEPT_NO where DEPT.DNOMBRE = @departamento";
            SqlParameter pamDept = new SqlParameter("@departamento", nombreDepartamento);
            this.com.Parameters.Add(pamDept);
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<EmpleadosDepartamentos> empleados = new List<EmpleadosDepartamentos>();

            while (await this.reader.ReadAsync())
            {
                int salario = int.Parse(this.reader["SALARIO"].ToString());
                string oficio = this.reader["OFICIO"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                EmpleadosDepartamentos emp = new EmpleadosDepartamentos();

                emp.Apellido = apellido;
                emp.Oficio = oficio;
                emp.Salario = salario;
                empleados.Add(emp);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return empleados;
        }

        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            string sql = "insert into DEPT values (@id, @nombre, @localidad)";
            SqlParameter pamId = new SqlParameter("@id", id);
            this.com.Parameters.Add(pamId);
            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);
            this.com.Parameters.Add(pamNombre);
            SqlParameter pamLocalidad = new SqlParameter("@localidad", localidad);
            this.com.Parameters.Add(pamLocalidad);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

        public async Task<EmpleadosDepartamentos> GetDatosEmpleadosAsync(string apellido)
        {
            string sql = "SELECT * FROM EMP WHERE APELLIDO=@apellido";
            this.com.Parameters.AddWithValue("@apellido", apellido);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            EmpleadosDepartamentos empleados = new EmpleadosDepartamentos();

            while (await this.reader.ReadAsync())
            {
                int salario = int.Parse(this.reader["SALARIO"].ToString());
                string oficio = this.reader["OFICIO"].ToString();
                string apellidoo = this.reader["APELLIDO"].ToString();
                empleados.Apellido = apellidoo;
                empleados.Oficio = oficio;
                empleados.Salario = salario;
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return empleados;
        }

        public async Task<int> UpdateEmpleadoAsync(string nuevoApellido, string viejoapellido, string oficio, int salario)
        {
            string sql = "UPDATE EMP SET APELLIDO=@nuevoapellido, OFICIO=@oficio, SALARIO=@salario WHERE APELLIDO = @viejoapellido";
            this.com.Parameters.AddWithValue("@nuevoApellido", nuevoApellido);
            this.com.Parameters.AddWithValue("@viejoapellido", viejoapellido);
            this.com.Parameters.AddWithValue("@oficio", oficio);
            this.com.Parameters.AddWithValue("@salario", salario);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int afectados = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return afectados;
        }
    }
}