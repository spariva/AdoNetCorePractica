using AdoNetCorePractica.Models;
using AdoNetCorePractica.Repositories;

namespace AdoNetCorePractica
{
    public partial class Form1 : Form
    {
        RepositoryHospital repo;

        public Form1()
        {
            InitializeComponent();
            this.repo = new RepositoryHospital();
            this.LoadHospitalesAsync();
        }

        private async Task LoadHospitalesAsync()
        {
            List<string> nombres =
                await this.repo.GetHospitalesAsync();
            this.cmbHospitales.Items.Clear();
            foreach (string nombre in nombres)
            {
                this.cmbHospitales.Items.Add(nombre);
            }
        }

        private async void cmbHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbHospitales.SelectedIndex != -1)
            {
                string nombre = 
                    this.cmbHospitales.SelectedItem.ToString();
                DatosEmpleados data =
                    await this.repo.GetDatosEmpleadosAsync(nombre);
                this.lstEmpleadosHospital.Items.Clear();
                foreach (Empleado emp in data.Empleados)
                {
                    this.lstEmpleadosHospital.Items.Add
                        (emp.Apellido + " - " + emp.Funcion + " - "
                        + emp.Salario);
                }
                this.txtSumaSalarial.Text = data.SumaSalarial.ToString();
                this.txtMediaSalarial.Text = data.MediaSalarial.ToString();
                this.txtPersonas.Text = data.Personas.ToString();
            }
        }
    }
}
