namespace WeeCompany.Cliente.Controllers
{
    using Dominio;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Text;
    using WeeCompany.Cliente.Models;
    public class CompaniaController : Controller
    {
        private readonly HttpClient _httpClient;
        public CompaniaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7294/api");
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompaniaModel datos)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(datos);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Companias", content);

                if (response.IsSuccessStatusCode)
                {
                    var Listaresponse = await _httpClient.GetAsync("/api/Companias");
                    if (Listaresponse.IsSuccessStatusCode)
                    {
                        var contenido = await Listaresponse.Content.ReadAsStringAsync();
                        var companias = JsonConvert.DeserializeObject<IEnumerable<CompaniaModel>>(contenido);
                        return PartialView("_ListaCompanias", companias);

                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el compania.");
                }
            }
            return View(datos);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MostrarModal()
        {
            return PartialView("_MostrarModal");
        }
    }
}
