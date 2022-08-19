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
    public class CategoryBusiness : ICategoryBusiness
    {
        ICategoryDal categoryDal;
        public CategoryBusiness(ICategoryDal categoryDal)
        {
            this.categoryDal=categoryDal;
        }

        

        public IDataResult<List<Category>> GetAllByCategories()
        {
            try
            {
                List<Category> categories = categoryDal.GetAll();
                SuccessDataResult<List<Category>> successDataResult = new SuccessDataResult<List<Category>>(categories, "tüm kategoriler");
                return successDataResult;
            }
            catch (Exception ex)
            {

               return new ErrorDataResult<List<Category>>(ex.Message);
            }
        }

        public IDataResult<Category> GetCategory(int id)
        {
           
            try
            {
                Category category = categoryDal.Get(c => c.CategoryId == id);
                SuccessDataResult<Category> successDataResult = new SuccessDataResult<Category>(category, "işlem başarılı");
                return successDataResult;
            }
            catch (Exception ex)
            {

               return new ErrorDataResult<Category>(ex.Message);
            }
        }
        public IResult CategoryAdd(Category category)
        {
            try
            {
                categoryDal.Add(category);
                SuccessResult successResult = new SuccessResult();
                return successResult;
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public IResult CategoryRemove(Category category)
        {
            try
            {
                categoryDal.Delete(category);
                SuccessResult successResult=new SuccessResult();
                return successResult;
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public IResult CategoryUpdate(Category category)
        {
            try
            {
                categoryDal.Update(category);
                SuccessResult successResult= new SuccessResult();
                return successResult;
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }
    }
}   

