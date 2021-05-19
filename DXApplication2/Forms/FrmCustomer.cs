using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DXApplication2.Models;
using Erbosan.DXApplication2;

namespace DXApplication2.Forms
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
        }
       
        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            GetList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtCustomerId.Text = gridView1.GetFocusedRowCellValue("CustomerId").ToString();
            txtCustomerName.Text = gridView1.GetFocusedRowCellValue("ContactName").ToString();
            txtCompanyName.Text = gridView1.GetFocusedRowCellValue("CompanyName").ToString();
            txtCity.Text = gridView1.GetFocusedRowCellValue("City").ToString();
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                ContactName = txtCustomerName.Text,
                CompanyName = txtCompanyName.Text,
                City = txtCity.Text
            };

            AddCustomer(customer);
            GetList();

            XtraMessageBox.Show("Müşteri başarılı bir şekilde sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon
                .Information);
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCustomerId.Text);

            DeleteCustomer(id);
            GetList();
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                CustomerId = Convert.ToInt32(txtCustomerId.Text),
                ContactName= txtCustomerName.Text,
                CompanyName = txtCompanyName.Text,
                City = txtCity.Text
            };
            UpdateCustomer(customer);
            GetList();
        }


        private static void AddCustomer(Customer customer)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = client.PostAsJsonAsync("customers/add", customer).Result;
        }

        private static void UpdateCustomer(Customer customer)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = client.PostAsJsonAsync("customers/update", customer).Result;
        }

        private static void DeleteCustomer(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = client.PostAsJsonAsync($"customers/delete/{id}", id).Result;
        }

        private void GetList()
        {
            var customers = GetCustomers();
            gridControl1.DataSource = customers;
        }

        private static IEnumerable<Customer> GetCustomers()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = client.GetAsync("customers/getall").Result;

            var customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            return customers;
        }
    }
}
