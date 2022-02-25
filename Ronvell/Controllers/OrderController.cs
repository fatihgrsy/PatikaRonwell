using Models.Orders;
using Ronvell.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace Ronvell.Controllers
{
    public class OrderController : ApiController
    {
        Business.Services.OrderService _order;
        public OrderController()
        {
            if (_order == null)
                _order = new Business.Services.OrderService();
        }

        [HttpPost]
        [Route("OrderAdd")]
        public Response<int> OrderAdd([FromBody] Order model)
        {
            try
            {
                int state = _order.OrderAdd(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpPut]
        [Route("OrderUpdate")]
        public Response<int> OrderUpdate([FromBody] Order model)
        {
            try
            {
                int state = _order.OrderUpdate(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpDelete]
        [Route("OrderDelete")]
        public Response<int> OrderDelete([FromUri] int id)
        {
            try
            {
                int state = _order.OrderDelete(id);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpGet]
        [Route("OrderByIds")]
        public Response<Order> OrderByIds([FromUri] int id)
        {
            try
            {
                var model = _order.GetSingleOrder(id);
                return BaseReturn.ReturnState<Order>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<Order>(0, null, ex.Message);
            }
        }

        [HttpGet]
        [Route("OrderGetAll")]
        public Response<List<Order>> OrderGetAll()
        {
            try
            {
                var model = _order.GetAllOrder();
                return BaseReturn.ReturnState<List<Order>>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<List<Order>>(0, null, ex.Message);
            }
        }
    }
}