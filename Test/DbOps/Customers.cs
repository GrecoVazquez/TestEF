using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    //CRUD
    class CustomersOps
    {
        private NorthwindEntities entities = new NorthwindEntities();       

       
        public List <Customer> GetCustomers()
        {
            return entities.Customers.ToList();
        }

        public Customer GetCustomerById(string id)
            
        {
            return entities.Customers.FirstOrDefault(c => c.CustomerID==id);
        }
        public void SetCustomer(Customer custom)
        {
            entities.Customers.Add(custom);
            entities.SaveChanges();
            
        }

        public void UpdateCustomerCompanyName(string id, string companyName)
        {
            var customer = GetCustomerById(id);
            if (customer != null)
            {
                customer.CompanyName = companyName;
                entities.SaveChanges();                   
            }
        }
        public void UpdateCustomer(string id,string companyName, string ContName, string ContTitle, string Addres,
                                   string city, string region, string CP, string pais, string cel, string fax)
        {
            var customer = GetCustomerById(id);
            if (customer != null)
            {
                customer.CompanyName = companyName;
                customer.ContactName = ContName;
                customer.ContactTitle = ContTitle;
                customer.Address = Addres;
                customer.City = city;
                customer.Region = region;
                customer.PostalCode = CP;
                customer.Country = pais;
                customer.Phone = cel;
                customer.Fax = fax;
                entities.SaveChanges();
            }
        }
        public void DeleteCustomer(string id)
        {
            var customer = GetCustomerById(id);            
            entities.Customers.Remove(customer);            
            entities.SaveChanges();          
        }

           
    }
}
