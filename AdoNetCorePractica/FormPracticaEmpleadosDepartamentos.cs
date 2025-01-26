using AdoNetCorePractica.Models;
using AdoNetCorePractica.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Runtime.InteropServices.JavaScript.JSType;

#region
//create procedure SP_ALL_DEPARTAMENTOS
//as
//select * from DEPT
//go
//CREATE PROCEDURE SP_DATOS_DEPARTAMENTOS
//(@nombre nvarchar(50))
//AS
//SELECT * FROM DEPT WHERE DNOMBRE=@nombre
//GO
#endregion

namespace AdoNetCorePractica
{
    public partial class FormPracticaEmpleadosDepartamentos : Form
    {
        RepositoryEmpleadosDepartamentos repo;
        public FormPracticaEmpleadosDepartamentos()
        {
            InitializeComponent();
            this.repo = new RepositoryEmpleadosDepartamentos();
            this.LoadDepartamentosAsync();
        }
        private async Task LoadDepartamentosAsync()
        {
            List<string> nombres = await this.repo.GetDepartamentosAsync();
            this.cmbDepartamentos.Items.Clear();
            foreach (string nombre in nombres)
            {
                this.cmbDepartamentos.Items.Add(nombre);
            }
        }

        private async Task LoadEmpleados()
        {
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();
            List<EmpleadosDepartamentos> datosEmpleados = await this.repo.GetEmpleadosDepartamentoAsync(nombre);

            this.lstEmpleados.Items.Clear();

            foreach (EmpleadosDepartamentos dato in datosEmpleados)
            {
                this.lstEmpleados.Items.Add(dato.Apellido + " - " + dato.Oficio + " - " + dato.Salario);
            }
        }

        

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string seleccionado = this.lstEmpleados.SelectedItem.ToString();
            string viejoapellido = seleccionado.Split('-')[0].Trim();
            string nuevoapellido = this.txtApellido.Text;
            string oficio = this.txtOficio.Text;
            int salario = int.Parse(this.txtSalario.Text);
            int modificados = await this.repo.UpdateEmpleadoAsync(nuevoapellido, viejoapellido, oficio, salario);
            MessageBox.Show("Empleados modificados " + modificados);
            this.LoadEmpleados();
        }

        private async void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();
            DatosDepratamentos dept = await this.repo.GetDatosDepartamentosAsync(nombre);
            this.txtId.Text = dept.IdDepartamento.ToString();
            this.txtNombre.Text = dept.Nombre;
            this.txtLocalidad.Text = dept.Localidad;
            
            List<EmpleadosDepartamentos> datosEmpleados = await this.repo.GetEmpleadosDepartamentoAsync(nombre);

            this.lstEmpleados.Items.Clear();

            foreach (EmpleadosDepartamentos dato in datosEmpleados)
            {
                this.lstEmpleados.Items.Add(dato.Apellido + " - " + dato.Oficio + " - " + dato.Salario);
            }
        }

        private async void btnInsertarDepartamento_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;
            await this.repo.InsertDepartamentoAsync(id, nombre, localidad);
            MessageBox.Show("Departamento insertado");
            this.LoadDepartamentosAsync();
        }

        private async void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedItem != null)
            {
                // El formato esperado es "Apellido - Oficio - Salario"
                string seleccionado = this.lstEmpleados.SelectedItem.ToString();
                string apellido = seleccionado.Split('-')[0].Trim(); 
                EmpleadosDepartamentos datosEmpleados = await this.repo.GetDatosEmpleadosAsync(apellido);
                this.txtApellido.Text = datosEmpleados.Apellido;
                this.txtOficio.Text = datosEmpleados.Oficio;
                this.txtSalario.Text = datosEmpleados.Salario.ToString();
            }
        }
    }
}