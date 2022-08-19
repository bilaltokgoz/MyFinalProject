using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductBusiness : IProductBusiness
    {
        IProductDal productDal;
       

        public ProductBusiness(IProductDal productDal)
        {
            this.productDal = productDal;
         
        }

        //public void AddProduct()
        //{
        //    throw new NotImplementedException();
        //}

        public IDataResult<List<Product>> GetAll()
        {

            //iş kodları
            //yetkisivarmı
            if (DateTime.Now.Hour == 22)
            {
                ErrorDataResult<List<Product>> errorDataResult = new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
                return errorDataResult;
            }
            try
            {
                List<Product> products = productDal.GetAll();
                SuccessDataResult<List<Product>> successDataResult = new SuccessDataResult<List<Product>>(products);
                return successDataResult;
            }
            catch (Exception)
            {

                throw;
            }
          
           
        }

        public IDataResult< List<Product>> GetAllByCategoryId()
        {
        
            try
            {
                List<Product> products = productDal.GetAll();
                SuccessDataResult<List<Product>> successDataResult = new SuccessDataResult<List<Product>>(products, "kategoriler listelendi");
                return successDataResult;
            }
            catch (Exception ex)
            {

                ErrorDataResult<List<Product>> errorDataResult = new ErrorDataResult<List<Product>>(ex.Message);
                return errorDataResult;
            }
            
        }
        public IDataResult< List<ProductDetailDto>> GetProductDetails()
        {
            try
            {
               List<ProductDetailDto>productDetails= productDal.GetProductDetails();
                SuccessDataResult<List<ProductDetailDto>> successDataResult = new SuccessDataResult<List<ProductDetailDto>>(productDetails);
                return successDataResult;

            }
            catch (Exception ex)
            {

                ErrorDataResult<List<ProductDetailDto>> errorDataResult = new ErrorDataResult<List<ProductDetailDto>>(ex.Message);
                return errorDataResult;
            }
        }
        public IDataResult< List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            try
            {
                productDal.Get(p => p.UnitPrice == min && p.UnitPrice== max);
                SuccessDataResult<List<Product>> successDataResult = new SuccessDataResult<List<Product>>();
                return successDataResult;
            }
            catch (Exception)
            {

               ErrorDataResult<List<Product>>errorDataResult = new ErrorDataResult<List<Product>>();
                return errorDataResult;
            }

        }
        public IDataResult< Product> GetById(int id)
        {
            try
            {
                Product product = productDal.Get(p => p.ProductId == id);
                    SuccessDataResult<Product>successDataResult = new SuccessDataResult<Product>(product);
                return successDataResult;

            }
            catch (Exception)
            {

               ErrorDataResult<Product>errorDataResult=new ErrorDataResult<Product>();
                return errorDataResult;
            }
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
           
            try
            {
                productDal.Add(product);
                SuccessResult successAdd = new SuccessResult(Messages.ProductAdded);

                return successAdd;
            }
            catch (Exception)
            {
                ErrorResult errorResult = new ErrorResult();
             return errorResult;
            }
            
            //if (product.ProductName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ProductInvalid);
            //}
         
        }

      
    }
}
