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
using DXApplication2.Helper;
using Erbosan.DXApplication2;

namespace DXApplication2.Forms
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            GetList();

            //var response=  RestHelper.GetAll();
            //gridControl1.DataSource = response;
        }

        private void GetList()
        {
            var products = GetProducts();
            gridControl1.DataSource = products;
        }

        private static IEnumerable<test> GetProducts()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = client.GetAsync("products/getall").Result;

            var products = response.Content.ReadAsAsync<IEnumerable<test>>().Result;
            return products;
        }


        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            //_ = RestHelper.CreateProductAsync(test);
            //GetList();

         
            test test = new test
            {
                productName = txtProductName.Text,
                unitPrice = Convert.ToInt32(txtUnitPrice.Text),
                unitsInStock = Convert.ToInt16(txtUnitsInStock.Text)
            };

            AddProduct(test);
            GetList();
          
            XtraMessageBox.Show("Ürün başarılı bir şekilde sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon
                .Information);
        }

        private static void AddProduct(test test)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = client.PostAsJsonAsync("products/add", test).Result;
        }

        private static void UpdateProduct(test test)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = client.PostAsJsonAsync("products/update", test).Result;
        }

        private static void DeleteProduct(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = client.PostAsJsonAsync($"products/delete/{id}", id).Result;
        }
        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(txtProductId.Text);
            
            DeleteProduct(id);
            GetList();
            
            
            
            

        }

        private void btnProductUpdate_Click(object sender, EventArgs e)
        {

            test test = new test
            {
                productId = Convert.ToInt32(txtProductId.Text),
                productName = txtProductName.Text,
                unitPrice = Convert.ToInt32(txtUnitPrice.Text),
                unitsInStock = Convert.ToInt16(txtUnitsInStock.Text)
            };
            UpdateProduct(test);
            GetList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtProductId.Text = gridView1.GetFocusedRowCellValue("productId").ToString();
            txtProductName.Text = gridView1.GetFocusedRowCellValue("productName").ToString();
            txtUnitsInStock.Text = gridView1.GetFocusedRowCellValue("unitsInStock").ToString();
            txtUnitPrice.Text = gridView1.GetFocusedRowCellValue("unitPrice").ToString();


        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            GetList();
        }
    }
}
