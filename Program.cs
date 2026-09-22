using System.Net.Http;
using System.Text.Json;

HttpClient client = new HttpClient();

string url = "https://api.disneyapi.dev/character/423";

try
{
    HttpResponseMessage response = await client.GetAsync(url);

    response.EnsureSuccessStatusCode();

    string json = await response.Content.ReadAsStringAsync();

    using JsonDocument document = JsonDocument.Parse(json);

    JsonElement root = document.RootElement;

    string nome = root.GetProperty("data").GetProperty("name").GetString() ?? "";
    string imagem = root.GetProperty("data").GetProperty("imageUrl").GetString() ?? "";

    Console.WriteLine("Nome:");
    Console.WriteLine(nome);

    Console.WriteLine();

    Console.WriteLine("Imagem:");
    Console.WriteLine(imagem);
}
catch (Exception ex)
{
    Console.WriteLine("Erro ao consumir a API:");
    Console.WriteLine(ex.Message);
}
