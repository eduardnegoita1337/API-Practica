using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Domain;
using WebApplication1.Models;

namespace WebApplication1.Controllers.CategoryControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public CategoriesRepresentation GetAll()
        {
            var dbCategories = _repo.GetCategories();
            return new CategoriesRepresentation(dbCategories);
        }
        [HttpPost]
        public async Task<Object> AddCategory([FromBody] Category category)
        {
            try
            {
                _repo.Insert(category);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [HttpDelete]
        public bool DeleteCategory(Category category)
        {
            try
            {
                _repo.Delete(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut]
        public bool UpdateCategory(Category category)
        {
            try
            {
                _repo.Update(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet(":Id")]
        public Object GetAllCategoriesById(int Id)
        {
            var data = _repo.GetById(Id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
       

    }
}
