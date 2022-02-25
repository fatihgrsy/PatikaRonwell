using Models.CustomerCarts;
using Ronvell.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Ronvell.Controllers
{
    public class CustomerCartController : ApiController
    {
        Business.Services.CustomerCartService _customerCart;

        public CustomerCartController()
        {
            if (_customerCart == null)
            {
                _customerCart = new Business.Services.CustomerCartService();
            }
        }


        [HttpPost]
        [Route("CustomerCartAdd")]
        public Response<int> CustomerCartAdd(CustomerCart model)
        {
            try
            {
                int state = _customerCart.CustomerCartAdd(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }
        [HttpPut]
        [Route("CustomerCartUpdate")]
        public Response<int> CustomerCartUpdate(CustomerCart model)
        {
            try
            {
                int state = _customerCart.CustomerCartUpdate(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }
        [HttpDelete]
        [Route("CustomerCartDelete")]
        public Response<int> CustomerCartDelete(int id)
        {
            try
            {
                int state = _customerCart.CustomerCartDelete(id);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpGet]
        [Route("CustomerCartGetAll")]
        public Response<List<CustomerCart>> CustomerCartGetAll()
        {
            try
            {
                var model = _customerCart.GetAllCustomerCart();
                return BaseReturn.ReturnState<List<CustomerCart>>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<List<CustomerCart>>(0, null, ex.Message);
            }
        }

        [HttpGet]
        [Route("CustomerCartByIds")]
        public Response<CustomerCart> CustomerCartByIds(int id)
        {
            try
            {
                var model = _customerCart.GetSingleCustomerCart(id);
                return BaseReturn.ReturnState<CustomerCart>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<CustomerCart>(0, null, ex.Message);
            }
        }
    }
}
