using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerBusiness
    {
        IDataResult<Customer> Get(string customerId);
        IDataResult<List<Customer>> GetAll();
        IResult AddCustomer(Customer customer);
        IResult Update(Customer customer);
        IResult CustomerDelete(Customer customer);

    }
}
