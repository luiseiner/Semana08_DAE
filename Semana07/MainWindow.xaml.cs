using Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Entity;

namespace Semana07
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
            customersB business = new customersB();
            dgPeople.ItemsSource = business.GetPeople();
        }


        private void Button_agregar(object sender, RoutedEventArgs e)
        {
            customersB business = new customersB(); 
            string nombre = name.Text;
            string direccion = addres.Text;
            string telefono = pone.Text;
            bool activo = activoCheckBox.IsChecked ?? false;

            
            Customer nuevoCliente = new Customer
            {
                Name = nombre,
                Address = direccion,
                Phone = telefono,
                Active = activo
            };

          
            business.InsertPerson(nuevoCliente);

            
            name.Clear();
            addres.Clear();
            pone.Clear();
            activoCheckBox.IsChecked = false; 
            dgPeople.ItemsSource = business.GetPeople();
        }


        private void EliminarSeleccionadoButton_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si hay un cliente seleccionado en el DataGrid
            if (dgPeople.SelectedItem != null)
            {
                // Obtener el cliente seleccionado
                Customer cliente = dgPeople.SelectedItem as Customer;

                // Obtener el ID del cliente seleccionado
                int clienteID = cliente.CustomerID;

                // Crear una instancia de la clase customersB
                customersB business = new customersB();

                // Llamar al método DeletePersonByID utilizando el ID del cliente
                business.DeletePersonByID(clienteID);

                // Actualizar el DataGrid para reflejar los cambios
                dgPeople.ItemsSource = business.GetPeople();
            }
            else
            {
                // Mostrar un mensaje indicando que no hay ningún cliente seleccionado
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Mensaje");
            }
        }


    }
}