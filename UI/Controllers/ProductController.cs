using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{

    public class ProductsController : ControllerBase
    {
        IProductBusiness productBusiness;
        public ProductsController(IProductBusiness productBusiness)
        {
            this.productBusiness = productBusiness;

        }
        [HttpGet]
        public IActionResult Add(Product product)
        {
            IResult result = productBusiness.AddProduct(product);
            if (result.Success == true)
            {
                return Ok("success");
            }
            else { return BadRequest(result.Message); }

        }
        [HttpGet]
        public IActionResult Get(int id)

        {
            IDataResult<Product> dataResult = productBusiness.GetById(id);

            return Ok(dataResult.Data);



        }
        [HttpGet]
        public IActionResult GetAll()
        {
           IDataResult<List<Product>> products= productBusiness.GetAll();
            return Ok(products);
        }
        [HttpGet]
        public IActionResult GetAllByCategoryId()
        {
           IDataResult<List<Product>>categories= productBusiness.GetAllByCategoryId();
            return Ok(categories.Data);
        }
    }
}
