using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerBusiness : ICustomerBusiness
    {
        ICustomerDal customerDal;
        public CustomerBusiness(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
        }
        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
              SuccessDataResult<List<Customer>> successDataResult=  new SuccessDataResult<List<Customer>>(customerDal.GetAll(),Messages.CustomerInvalid);

                return successDataResult;
            }
            catch (Exception ex)
            {

              return new ErrorDataResult<List<Customer>>(ex.Message);
            }
        }

        public IDataResult<Customer> Get(string customerId)
        {
            try
            {
                Customer customer = customerDal.Get(c => c.CustomerId==customerId);
                SuccessDataResult<Customer>successDataResult= new SuccessDataResult<Customer>(customer,"");

                return successDataResult;
            }
            catch (Exception ex)
            {

              return new ErrorDataResult<Customer>(ex.Message);
            }
        }
        public IResult AddCustomer(Customer customer)
        {
            try
            {
                customerDal.Add(customer);
                SuccessResult successResult = new SuccessResult();
                return successResult;

            }
            catch (Exception ex)
            {

              return new ErrorResult(ex.Message);
            }
        }

        public IResult CustomerDelete(Customer customer)
        {
            try
            {
                customerDal.Delete(customer);
                SuccessResult successResult = new SuccessResult("silindi");
                return successResult;


            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

       

        public IResult Update(Customer customer)
        {
            try
            {
               
                customerDal.Update(new Customer {CustomerId=customer.CustomerId,CompanyName=customer.CompanyName,ContactName=customer.ContactName});
                SuccessResult successResult = new SuccessResult("ürün güncellendi");
                return successResult;

            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }
    }
}   

