using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using WS.VirtualStore.Web;
using WS.VirtualStore.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44367/") });



await builder.Build().RunAsync();
