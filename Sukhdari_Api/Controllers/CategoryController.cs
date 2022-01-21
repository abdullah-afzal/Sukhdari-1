﻿using Business.IRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sukhdari_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IProductRepo _productRepo;

        public CategoryController(ICategoryRepo categoryRepo,IProductRepo productRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
        }

        [HttpGet("{storeId}")]
        public async Task<IActionResult> GetAllCategories(int? storeId)
        {
            var categories = await _categoryRepo.GetAllCategories(storeId.Value);
            return Ok(categories);
        }

        [HttpGet("{id},{storeId}")]
        public async Task<IActionResult> GetCategory(int? id,int? storeId)
        {
            var category = await _categoryRepo.GetCategory(id.Value, storeId.Value);
            return Ok(category);
        }

        [HttpGet("{categoryName}")]
        public async Task<IActionResult> GetProductsWithCategoryName(string? categoryName)
        {
            var products = await _productRepo.getAllProducts();
            var category = await _categoryRepo.GetAllCategories();

            var categoryToFind = category.FirstOrDefault(i => i.Name.ToLower().Contains(categoryName.ToLower()));
            var productsToFind = products.Where(x => x.CategoryId == categoryToFind.Id);
            //var categoryToFind = category.Where(x => x.Name.Trim().ToLower().Contains(categoryName.ToLower())).Select(x => x.Id);
            //var productsToFind = products.All(x => products.Any(a => a.CategoryId.Equals(categoryToFind)));
            return Ok(productsToFind);
        }
    }
}