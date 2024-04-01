using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.ProductDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _productService = ProductService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "Product";
            TempData["Action"] = "Index";

            return View(_mapper.Map<List<ResultProductDto>>(await _productService.TGetAllAsync()));
        }

        public async Task<IActionResult> DeleteProduct(ObjectId id)
        {
            await _productService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(ObjectId id)
        {
            TempData["Controller"] = "Product";
            TempData["Action"] = "Update Product";

            return View(_mapper.Map<UpdateProductDto>(await _productService.TGetByIdAsync(id)));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProduct)
        {
            await _productService.TUpdateAsync(_mapper.Map<Product>(updateProduct));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            TempData["Controller"] = "Product";
            TempData["Action"] = "Create Product";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProduct)
        {
            await _productService.TCreateAsync(_mapper.Map<Product>(createProduct));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(ObjectId id)
        {
            TempData["Controller"] = "Product";
            TempData["Action"] = "Product Details";

            return View(_mapper.Map<ResultProductDto>(await _productService.TGetByIdAsync(id)));    
        }
    }
}
