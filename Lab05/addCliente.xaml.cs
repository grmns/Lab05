using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab05
{
    /// <summary>
    /// Lógica de interacción para addCliente.xaml
    /// </summary>
    public partial class addCliente : Window
    {
        private string connectionString = "Server=DESKTOP-OT3T8Q7; Database=Neptuno; User Id=userNeptuno; Password=123456;";

        public addCliente()
        {
            InitializeComponent();
        }
        private void AgregarCliente(string idCliente, string nombreCompañia, string nombreContacto, string cargoContacto, string direccion, string ciudad, string region, string codPostal, string pais, string telefono, string fax)
        {
            string query = "sp_CrearCliente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter param1 = new SqlParameter("@idCliente", SqlDbType.VarChar, 5);
                        param1.Value = idCliente;
                        command.Parameters.Add(param1);

                        SqlParameter param2 = new SqlParameter("@NombreCompañia", SqlDbType.VarChar, 100);
                        param2.Value = nombreCompañia;
                        command.Parameters.Add(param2);

                        SqlParameter param3 = new SqlParameter("@NombreContacto", SqlDbType.VarChar, 100);
                        param3.Value = nombreContacto;
                        command.Parameters.Add(param3);

                        SqlParameter param4 = new SqlParameter("@CargoContacto", SqlDbType.VarChar, 100);
                        param4.Value = cargoContacto;
                        command.Parameters.Add(param4);

                        SqlParameter param5 = new SqlParameter("@Direccion", SqlDbType.VarChar, 100);
                        param5.Value = direccion;
                        command.Parameters.Add(param5);

                        SqlParameter param6 = new SqlParameter("@Ciudad", SqlDbType.VarChar, 100);
                        param6.Value = ciudad;
                        command.Parameters.Add(param6);

                        SqlParameter param7 = new SqlParameter("@Region", SqlDbType.VarChar, 100);
                        param7.Value = region;
                        command.Parameters.Add(param7);

                        SqlParameter param8 = new SqlParameter("@CodPostal", SqlDbType.VarChar, 100);
                        param8.Value = codPostal;
                        command.Parameters.Add(param8);

                        SqlParameter param9 = new SqlParameter("@Pais", SqlDbType.VarChar, 100);
                        param9.Value = pais;
                        command.Parameters.Add(param9);

                        SqlParameter param10 = new SqlParameter("@Telefono", SqlDbType.VarChar, 30);
                        param10.Value = telefono;
                        command.Parameters.Add(param10);

                        SqlParameter param11 = new SqlParameter("@Fax", SqlDbType.VarChar, 30);
                        param11.Value = fax;
                        command.Parameters.Add(param11);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} fila(s) insertada(s).");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al agregar cliente: " + ex.Message);
                }
            }
        }

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            string idCliente = txtIdCliente.Text;
            string nombreCompañia = txtNombreCompañia.Text;
            string nombreContacto = txtNombreContacto.Text;
            string cargoContacto = txtCargoContacto.Text;
            string direccion = txtDireccion.Text;
            string ciudad = txtCiudad.Text;
            string region = txtRegion.Text;
            string codPostal = txtCodPostal.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            string fax = txtFax.Text;

            AgregarCliente(idCliente, nombreCompañia, nombreContacto, cargoContacto, direccion, ciudad, region, codPostal, pais, telefono, fax);

        }
    }
}