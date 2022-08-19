using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
       
        IEmployeeDal employeeDal;
     
        



        public EmployeeBusiness(IEmployeeDal employeeDal)
        {
            this.employeeDal = employeeDal;
        
            
        }
       

        public IDataResult<List<Employee>> GetAll()
        {
            try
            {
                SuccessDataResult<List<Employee>> successDataResult = new SuccessDataResult<List<Employee>>(employeeDal.GetAll(), "kullanıcı listesi");
                return successDataResult;
            }
            catch (Exception ex)
            {

              return new ErrorDataResult<List<Employee>>(ex.Message);
            }
    
         
         
        }

        public IDataResult<List<Employee>> GetAllByCategoryId(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception )
            {

                throw;
            }
        }

        public IDataResult<Employee> Get(int id)
        {
            try
            {
             Employee employee=employeeDal.Get(u=>u.EmployeeId==id);
                SuccessDataResult<Employee>successDataResult=new SuccessDataResult<Employee>(employee,"kullanıcı adı");
                return successDataResult;
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Employee>(ex.Message);
            }
        }
        public IResult EmployeeAdded(Employee emplooyee)
        {
            try
            {
                employeeDal.Add(emplooyee);
                SuccessResult successResult = new SuccessResult("kullanıcı eklendi");
                return successResult;
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }
        public IResult EmployeeUpdate(Employee emplooyee)
        {
           
            try
            {
              
                    employeeDal.Update(emplooyee);

            
                SuccessResult successResult = new SuccessResult("ürün güncelle");
                return successResult;
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }
        public IResult Delete(Employee employee)
        {
            try
            {
                employeeDal.Delete(employee);
                SuccessResult successResult = new SuccessResult();
                return successResult;

            }
            catch ( Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }


    }
}   

