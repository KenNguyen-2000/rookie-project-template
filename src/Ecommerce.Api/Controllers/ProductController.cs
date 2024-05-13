using Ecommerce.Application.Services.Product;
using Ecommerce.Application.Services.Product.Dtos;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(CancellationToken cancellationToken)
        {
            var products = await _productService.GetListProduct(cancellationToken);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //Implement create login here
            return Ok();
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<ProductDto>> GetProduct(int id, CancellationToken cancellationToken)
        // {
        //     var product = await _productService.GetProductAsync(id, cancellationToken);
        //     return Ok(product);
        // }

        // [HttpPost]
        // public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductCommand command, CancellationToken cancellationToken)
        // {
        //     var product = await _productService.CreateProductAsync(command, cancellationToken);
        //     await _unitOfWork.SaveChangesAsync(cancellationToken);
        //     return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<ProductDto>> UpdateProduct(int id, UpdateProductCommand command, CancellationToken cancellationToken)
        // {
        //     var product = await _productService.UpdateProductAsync(id, command, cancellationToken);
        //     await _unitOfWork.SaveChangesAsync(cancellationToken);
        //     return Ok(product);
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        // {
        //     await _productService.DeleteProductAsync(id, cancellationToken);
        //     await _unitOfWork.SaveChangesAsync(cancellationToken);
        //     return NoContent();
        // }
    }
}