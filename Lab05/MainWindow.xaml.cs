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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab05
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Server=DESKTOP-OT3T8Q7; Database=Neptuno; User Id=userNeptuno; Password=123456;";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListarClientes()
        {
            string query = "EXEC sp_LeerCliente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridClientes.ItemsSource = dt.DefaultView;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al listar clientes: " + ex.Message);
                }
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ListarClientes();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            addCliente addCliente = new addCliente();
            addCliente.ShowDialog();
        }
    }
}