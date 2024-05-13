using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.CustomerFe.Models;
using Ecommerce.CustomerFe.Services.Product;

namespace Ecommerce.CustomerFe.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductApiClient _productApiClient;

    public ProductsController(ILogger<ProductsController> logger, IProductApiClient productApiClient)
    {
        _logger = logger;
        _productApiClient = productApiClient;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Get products from API");
        var products = await _productApiClient.GetProducts(CancellationToken.None);
        ViewData["Products"] = products;
        return View(products);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
