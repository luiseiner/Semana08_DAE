using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class customersData
    {
        private string connectionString = "Data Source=LAB1504-10\\SQLEXPRESS; Initial Catalog=NeptunoDB; User Id=Luis; Password=123456";

        public List<Customer> GetPeople()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ListCustomers", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerID = reader.GetInt32(reader.GetOrdinal("customer_id"));

                        customer.Name = reader["name"].ToString();
                        customer.Address = reader["address"].ToString();
                        customer.Phone = reader["phone"].ToString();
                        customer.Active = Convert.ToBoolean(reader["active"]);

                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }
        public void InsertPerson(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@name", customer.Name);
                command.Parameters.AddWithValue("@address", customer.Address);
                command.Parameters.AddWithValue("@phone", customer.Phone);
                command.Parameters.AddWithValue("@active", customer.Active);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeletePersonByID(int customerID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DeleteCustomerByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@customer_id", customerID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Capturar y manejar cualquier excepción que ocurra durante la eliminación del cliente
                Console.WriteLine("Error al eliminar el cliente: " + ex.Message);
                throw; // Relanzar la excepción para que pueda ser manejada en el código que llama a este método
            }
        }

    }
}
