using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public async Task<int> CreateProduct(CreateProductDto productDto)
        {
            if (productDto is null
                || string.IsNullOrWhiteSpace(productDto.Name)
                || string.IsNullOrWhiteSpace(productDto.ProductNumber))
            {
                throw new BadRequestException("Product info is not valid.");
            }

            Product product = new Product
            {
                Name = productDto.Name,
                ProductNumber = productDto.ProductNumber,
                MakeFlag = productDto.MakeFlag,
                FinishedGoodsFlag = productDto.FinishedGoodsFlag,
                SafetyStockLevel = productDto.SafetyStockLevel,
                ReorderPoint = productDto.ReorderPoint,
                StandardCost = productDto.StandardCost,
                ListPrice = productDto.ListPrice,
                SellStartDate = productDto.SellStartDate
            };

            return await _productRepository.CreateProduct(product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var product = await ValidateProductExistence(id);
            return await _productRepository.DeleteProduct(product);
        }

        public async Task<IEnumerable<GetProductDto>> GetAll()
        {
            var products = await _productRepository.GetAllProducts();
            List<GetProductDto> productsDto = new List<GetProductDto>();

            foreach (var product in products)
            {
                GetProductDto dto = new GetProductDto
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber
                };

                productsDto.Add(dto);
            }

            return productsDto;
        }

        public async Task<GetProductDto?> GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ProductID is not valid");
            }

            var product = await ValidateProductExistence(id);

            GetProductDto dto = new GetProductDto
            {
                ProductID = product.ProductID,
                Name = product.Name,
                ProductNumber = product.ProductNumber
            };
            return dto;
        }

        public async Task<int> UpdateProduct(UpdateProductDto productDto)
        {
            if (productDto is null)
            {
                throw new BadRequestException("Product info is not valid.");
            }
            var product = await ValidateProductExistence(productDto.ProductID);

            product.Name = string.IsNullOrWhiteSpace(productDto.Name) ? product.Name : productDto.Name;
            product.ProductNumber = string.IsNullOrWhiteSpace(productDto.ProductNumber) ? product.ProductNumber : productDto.ProductNumber;
            product.MakeFlag = productDto.MakeFlag;
            product.FinishedGoodsFlag = productDto.FinishedGoodsFlag;
            product.SafetyStockLevel = productDto.SafetyStockLevel;
            product.ReorderPoint = productDto.ReorderPoint;
            product.StandardCost = productDto.StandardCost;
            product.ListPrice = productDto.ListPrice;
            product.SellStartDate = productDto.SellStartDate;

            return await _productRepository.UpdateProduct(product);
        }

        private async Task<Product> ValidateProductExistence(int id)
        {
            var existingProduct = await _productRepository.GetProductById(id)
                ?? throw new NotFoundException($"Product with Id: {id} was not found.");

            return existingProduct;
        }
    }
}
