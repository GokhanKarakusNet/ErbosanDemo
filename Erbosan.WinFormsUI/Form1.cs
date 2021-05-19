using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Erbosan.DataAccess.Concrete.EntityFramework;
using Erbosan.Entities.Concrete;
using Newtonsoft.Json;
using JsonExtensionDataAttribute = System.Text.Json.Serialization.JsonExtensionDataAttribute;

namespace Erbosan.WinFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = client.GetAsync("products/getall").Result;
            
            var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dgwProduct.DataSource = products;

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
