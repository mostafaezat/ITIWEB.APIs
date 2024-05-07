﻿using AutoMapper;
using Core.Entities;
using Core.Repositories;
using Core.Specifications;
using ITIWEB.APIs.DTOs;
using ITIWEB.APIs.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITIWEB.APIs.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // Get : api/Product
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    var products = await _productRepository.GetAllAsync();
        //    return Ok(products);
        //}

        // Get : api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsWithSpec(string? sort, int? brandId, int? typeId)
        {
            var spec = new ProductWithBrandAndTypeSpec(sort, brandId, typeId);
            var products =  await _productRepository.GetAllWithSpecAsync(spec);
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>> (products));
        }

   


        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    var product = await _productRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductWithBrandAndTypeSpec(id);
            var product = await _productRepository.GetByIdWithSpecAsync(spec);
            //if (product == null) return NotFound();
            if (product == null) return  NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Product, ProductDto>(product));
        }

    }
}
