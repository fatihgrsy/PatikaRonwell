using Models.PriceTags;
using Ronvell.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace Ronvell.Controllers
{
    public class PriceTagController : ApiController
    {

        Business.Services.PriceTagService _priceTag;
        public PriceTagController()
        {
            if (_priceTag == null)
            {
                _priceTag = new Business.Services.PriceTagService();
            }
        }


        [HttpPost]
        [Route("PriceTagAdd")]
        public Response<int> PriceTagAdd([FromBody] PriceTag model)
        {
            try
            {
                int state = _priceTag.PriceTagAdd(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpPut]
        [Route("PriceTagUpdate")]
        public Response<int> PriceTagUpdate([FromBody] PriceTag model)
        {
            try
            {
                int state = _priceTag.PriceTagUpdate(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpDelete]
        [Route("PriceTagDelete")]
        public Response<int> PriceTagDelete([FromUri] int id)
        {
            try
            {
                int state = _priceTag.PriceTagDelete(id);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpGet]
        [Route("PriceTagByIds")]
        public Response<PriceTag> PriceTagByIds([FromUri] int id)
        {
            try
            {
                var model = _priceTag.GetSinglePriceTag(id);
                return BaseReturn.ReturnState<PriceTag>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<PriceTag>(0, null, ex.Message);
            }
        }

        [HttpGet]
        [Route("PriceTagGetAll")]
        public Response<List<PriceTag>> PriceTagGetAll()
        {
            try
            {
                var model = _priceTag.GetAllPriceTag();
                return BaseReturn.ReturnState<List<PriceTag>>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<List<PriceTag>>(0, null, ex.Message);
            }
        }

    }
}