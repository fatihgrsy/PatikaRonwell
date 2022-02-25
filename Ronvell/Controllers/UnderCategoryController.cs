using Models.Categories;
using Ronvell.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Ronvell.Controllers
{
    public class UnderCategoryController : ApiController
    {

        Business.Services.UnderCategoryService _underCategory;
        public UnderCategoryController()
        {
            if (_underCategory == null)
                _underCategory = new Business.Services.UnderCategoryService();
        }


        [HttpPost]
        [Route("UnderCategoryAdd")]
        public Response<int> UnderCategoryAdd([FromBody] UnderCategory model)
        {
            try
            {
                int state = _underCategory.UnderCategoryAdd(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpPut]
        [Route("UnderCategoryUpdate")]
        public Response<int> UnderCategoryUpdate([FromBody] UnderCategory model)
        {
            try
            {
                int state = _underCategory.UnderCategoryUpdate(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpPut]
        [Route("UnderCategoryDelete")]
        public Response<int> UnderCategoryDelete([FromUri] int id)
        {
            try
            {
                int state = _underCategory.UnderCategoryDelete(id);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpGet]
        [Route("UnderCategoryGetAll")]
        public Response<List<UnderCategory>> UnderCategoryGetAll()
        {
            try
            {
                var model = _underCategory.GetAllUnderCategory();
                return BaseReturn.ReturnState<List<UnderCategory>>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<List<UnderCategory>>(0, null, ex.Message);
            }
        }

        [HttpGet]
        [Route("UnderCategoryByIds")]
        public Response<UnderCategory> UnderCategoryByIds([FromUri] int id)
        {
            try
            {
                var model = _underCategory.GetSingleUnderCategory(id);
                return BaseReturn.ReturnState<UnderCategory>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<UnderCategory>(0, null, ex.Message);
            }
        }


    }
}