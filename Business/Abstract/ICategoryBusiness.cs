using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryBusiness
    {
        
        
        IDataResult<Category> GetCategory(int id);
        IDataResult<List<Category>> GetAllByCategories();
        IResult CategoryAdd(Category category);
        IResult CategoryRemove(Category category);
        IResult CategoryUpdate(Category category);
    }
}
