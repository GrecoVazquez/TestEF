using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        CustomersOps methods = new CustomersOps();
        public Form1()
        {
            InitializeComponent();
        }
    
        
        private void Consultar_Click(object sender, EventArgs e)
        {
            consulta_general();
        }

        private void ConsultEspe_Click(object sender, EventArgs e)
        {
            if (idSearch.Text.Equals(""))
            {
                MessageBox.Show("Ingrese un ID a consultar");
            }
            else
            {
                string res = idSearch.Text.ToUpper();
                Customer resu = methods.GetCustomerById(res);               
                    idSearch.Text = resu.CustomerID;
                    companyN.Text = resu.CompanyName;
                    ContactN.Text = resu.ContactName;
                    contactTi.Text = resu.ContactTitle;
                    addr.Text = resu.Address;
                    ciudad.Text = resu.City;
                    regi.Text = resu.Region;
                    cp.Text = resu.PostalCode;
                    paiss.Text = resu.Country;
                    phonee.Text = resu.Phone;
                    fats.Text = resu.Fax;              
            }
            
        }
        private void consulta_general()
           {
            foreach (Customer c in methods.GetCustomers())
            {
                Resultado.Items.Add(c.CustomerID + "\t" + c.CompanyName);
            }           
           }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (idSearch.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el ID del customer a eliminar");
               
            }
            else
            {
                methods.DeleteCustomer(idSearch.Text);
                idSearch.Text = "";
                limpia();
                MessageBox.Show("Eliminado correctamente");


            }
        }

        private void Insertar_Click(object sender, EventArgs e)
        {
           
                Customer customer = new Customer();        
                customer.CustomerID = idSearch.Text;
                customer.CompanyName = companyN.Text;
                customer.ContactName = ContactN.Text;
                customer.ContactTitle = contactTi.Text;
                customer.Address = addr.Text;
                customer.City = ciudad.Text;
                customer.Region = regi.Text;
                customer.PostalCode = cp.Text;
                customer.Country = paiss.Text;
                customer.Phone = phonee.Text;
                customer.Fax = fats.Text;

                methods.SetCustomer(customer);
                limpia();
                MessageBox.Show("Datos ingresados correctamente");            
        }

        private void actCompanyName_Click(object sender, EventArgs e)
        {            
            methods.UpdateCustomerCompanyName(idSearch.Text, companyN.Text);
            MessageBox.Show("Actualizado correctamente");

        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            limpia();
        }

        public void limpia()
        {
            idSearch.Text = "";
            companyN.Text = "";
            ContactN.Text = "";
            contactTi.Text = "";
            addr.Text = "";
            ciudad.Text = "";
            regi.Text = "";
            cp.Text = "";
            paiss.Text = "";
            phonee.Text = "";
            fats.Text = "";
        }
    }
}
