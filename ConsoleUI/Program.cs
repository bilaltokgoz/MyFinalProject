using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using DataAccess.Abstract;
using Business.Abstract;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            IProductBusiness productBusiness = new ProductBusiness(new EfProductDal());
            var result = productBusiness.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }


          
        }
       

    }
}