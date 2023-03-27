using System.Net.Http.Json;
using System.Text.Json;

//internal class Program
//{
//    private static async Task Main(string[] args)
//    {
//        HttpClient client = new HttpClient();
//        Product.Root root = (Product.Root)await client.GetFromJsonAsync("https://dummyjson.com/products", typeof(Product.Root));

//        string jSonString = JsonSerializer.Serialize(root);
//        string Json = File.ReadAllText(jSonString);
//        Product product = JsonSerializer.Deserialize<Product>(Json);
//    }

//}