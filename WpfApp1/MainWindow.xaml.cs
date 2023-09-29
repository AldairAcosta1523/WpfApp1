using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAB1504-25\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=tecsup;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("InsertarProducto", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", int.Parse(txtIdProducto.Text));
                    cmd.Parameters.AddWithValue("@nombreProducto", txtNombreProducto.Text);
                    cmd.Parameters.AddWithValue("@idProveedor", textIdProveedor.Text);
                    cmd.Parameters.AddWithValue("@idCategoria", txtIdCategoria.Text);
                    cmd.Parameters.AddWithValue("@cantidadPorUnidad", txtCantidadPorUnidad.Text);
                    cmd.Parameters.AddWithValue("@precioUnidad", txtPrecioUidad.Text);
                    cmd.Parameters.AddWithValue("@unidadesEnExistencia", txtUnidadesExistencia.Text);
                    cmd.Parameters.AddWithValue("@unidadesEnPedido", txtUnidadesPedido.Text);
                    cmd.Parameters.AddWithValue("@nivelNuevoPedido", txtNivelPedido.Text);
                    cmd.Parameters.AddWithValue("@suspendido", txtSuspendido.Text);
                    cmd.Parameters.AddWithValue("@categoriaProducto", txtCategoria_Producto.Text);
                    cmd.Parameters.AddWithValue("@activo", 1);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto ingresada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el Producto: " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                Window1 window1 = new Window1();
                window1.Show();
            }
        }
    }
}
