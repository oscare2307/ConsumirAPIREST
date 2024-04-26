using ConsumirAPIREST.Modelo;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ConsumirAPIREST
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductId = ProductoIdLabel.Text;
            product.ProductName = ProductoName.Text;
            product.CategoryId = CategoriaId.Text;
            product.ProductPrice = ProductoPrice.Text;
            
            await CrearProduct(product);
            await DisplayAlert("Creado", "El producto se ha creado", "OK");
        }
            private async Task<Product> CrearProduct(Product product)
            {
                using (var http = new HttpClient())
                {
                    // **Your code snippet goes here:**

                    http.BaseAddress = new Uri("https://apis.cootramixtol.com/products/products"); // Optional if not using base address

                    var cuerpo = JsonSerializer.Serialize(product);
                    var data = new StringContent(cuerpo, Encoding.UTF8, "application/json");

                    var resp = await http.PostAsync($"https://apis.cootramixtol.com/products/products", data);

                    if (resp.IsSuccessStatusCode)
                    {
                        var respoBody = await resp.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<Product>(respoBody);
                    }
                    else
                    {
                    return null;
                    }
                }
                    
            }
    }
}      
