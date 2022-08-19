using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmployeeBusiness
    {
       IDataResult< List<Employee>> GetAll();
       IDataResult< List<Employee> >GetAllByCategoryId(int id);
       IDataResult<Employee> Get(int id);
        IResult EmployeeAdded(Employee emplooyee);
        IResult EmployeeUpdate(Employee emplooyee);
        IResult Delete(Employee emplooyee);


    }
}
