using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Erbosan.DXApplication2;

namespace DXApplication2.Helper
{
    public static class RestHelper
    {
        private static readonly string baseURL = "https://localhost:44351/api/";

        public static  Task<test> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res =  client.GetAsync(baseURL+"products/getall").Result)
                {
                    using (HttpContent content=res.Content)
                    {
                        var data =  content.ReadAsAsync<Task<test>>().Result;
                        if (data!=null)
                        {
                            return data;
                        }
                        
                    }
                }
            }

            return null;
        }


       public  static HttpClient client = new HttpClient();

        public static async Task<Uri> CreateProductAsync(test test)
        {
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "products/add", test);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public static async Task<test> DeleteProductAsync(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            HttpResponseMessage response = await client.PostAsJsonAsync(
                $"products/delete/{id}", id);
            var test = await response.Content.ReadAsAsync<test>();
            return test;
        }

        public static async Task<test> UpdateProductAsync(test test)
        {
            client.BaseAddress = new Uri("https://localhost:44351/api/");

            HttpResponseMessage response = await client.PutAsJsonAsync(
                "products/update", test);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            test = await response.Content.ReadAsAsync<test>();
            return test;
        }

        public static async  Task<test> GetProductAsync(string path)
        {
            client.BaseAddress = new Uri("https://localhost:44351/api/");

            test test = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                test = await response.Content.ReadAsAsync<test>();
            }
            return test;
        }

        

       public static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:44351/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
