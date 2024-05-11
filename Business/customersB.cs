using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Data;
using Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Business
{
    public class customersB
    {
        public List<Customer> GetPeople()
        {

            List<Customer> people = new List<Customer>();
            customersData data = new customersData();
            people = data.GetPeople();
            return people;

        }
        public void InsertPerson(Customer customer)
        {
            customersData data = new customersData();
            data.InsertPerson(customer);
        }

        public void DeletePersonByID(int customerID)
        {
            customersData data = new customersData();
            data.DeletePersonByID(customerID);
        }

    }
}
