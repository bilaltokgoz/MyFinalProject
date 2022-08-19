using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{
 
    public class EmployeesController : ControllerBase
    {
        IEmployeeBusiness employeeBusiness;
        public EmployeesController(IEmployeeBusiness employeeBusiness)
        {
            this.employeeBusiness = employeeBusiness;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            IDataResult<Employee> employee = employeeBusiness.Get(id);
            return Ok(employee);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           IDataResult<List<Employee>>employees= employeeBusiness.GetAll();
            return Ok(employees);
        }
    }
}
