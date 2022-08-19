using Core.Repository;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfRepository<Product, EfContext>, IProductDal

    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (EfContext context =new EfContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductName=p.ProductName,CategoryName=c.CategoryName};
                
                return result.ToList();
            }  
          
        }
      
    }
}