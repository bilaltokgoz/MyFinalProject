﻿
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Employee:IEntity
    {
        public int EmployeeId  { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }

    }
}
