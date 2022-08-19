using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{

    public class CategoryController : ControllerBase
    {
        ICategoryBusiness categoryBusiness;
        public CategoryController(ICategoryBusiness categoryBusiness)
        {
            this.categoryBusiness = categoryBusiness;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            IDataResult<Category> category = categoryBusiness.GetCategory(id);
            return Ok(category.Data);

        }
        [HttpGet]
        public IActionResult GetAllByCategories()
        {
           IDataResult<List<Category>>categories= categoryBusiness.GetAllByCategories();
            return Ok(categories);
        }
    }
}
