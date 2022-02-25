using Models.Categories;
using Ronvell.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Ronvell.Controllers
{
    public class CategoryController : ApiController
    {


        Business.Services.CategoryService _category;

        public CategoryController()
        {
            if (_category == null)
            {
                _category = new Business.Services.CategoryService();
            }
        }



        [HttpPost]
        [Route("CategoryAdd")]
        public Response<int> CategoryAdd([FromBody]Category model)
        {
            try
            {
                int state = _category.CategoryAdd(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpPost]
        [Route("CategoryAddBulk")]
        public Response<int> CategoryAddBulk([FromBody] Category model)
        {
            List<Category> list = new List<Category>();
            try
            {
                for (int i = 0; i < 1000000; i++)
                {
                    list.Add(new Category
                    {
                        Id=0,
                        CategoryTypes= "CategoryTypes : "+i
                    });
                }
                _category.CategoryAddBulk(list);
                return BaseReturn.ReturnState<int>(1, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpPut]
        [Route("CategoryUpdate")]
        public Response<int> CategoryUpdate([FromBody]Category model)
        {
            try
            {
                int state = _category.CategoryUpdate(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpDelete]
        [Route("CategoryDelete")]
        public Response<int> CategoryDelete([FromUri]int id)
        {
            try
            {
                int state = _category.CategoryDelete(id);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpGet]
        [Route("CategoryByIds")]
        public Response<Category> CategoryByIds([FromUri] int id)
        {
            try
            {
                var model = _category.GetSingleCategory(id);
                return BaseReturn.ReturnState<Category>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<Category>(0, null, ex.Message);
            }
        }

        [HttpGet]
        [Route("CategoryGetAll")]
        public Response<List<Category>> CategoryGetAll()
        {
            try
            {
                var model = _category.GetAllCategory();
                return BaseReturn.ReturnState<List<Category>>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<List<Category>>(0, null, ex.Message);
            }
        }

    }
}