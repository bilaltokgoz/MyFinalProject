using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductBusiness
    {
       IDataResult< List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId();
        IDataResult<List<Product> >GetByUnitPrice(decimal min, decimal max);
        IDataResult <List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product>GetById(int id);
        IResult AddProduct(Product product);


    }
}
