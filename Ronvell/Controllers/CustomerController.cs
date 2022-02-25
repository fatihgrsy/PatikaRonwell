using Models.Customers;
using Ronvell.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace Ronvell.Controllers
{
    public class CustomerController : ApiController
    {

        Business.Services.CustomerService _customer;
        public CustomerController()
        {
            if (_customer == null)
                _customer = new Business.Services.CustomerService();

          
        }

        [HttpPost]
        [Route("CustomerAdd")]
        public Response<int> CustomerAdd([FromBody] Customer model)
        {
            try
            {
                int state = _customer.CustomerAdd(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpPut]
        [Route("CustomerUpdate")]
        public Response<int> CustomerUpdate([FromBody] Customer model)
        {
            try
            {
                int state = _customer.CustomerUpdate(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpDelete]
        [Route("CustomerDelete")]
        public Response<int> CustomerDelete([FromUri] int id)
        {
            try
            {
                int state = _customer.CustomerDelete(id);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpGet]
        [Route("CustomerByIds")]
        public Response<Customer> CustomerByIds([FromUri] int id)
        {
            try
            {
                var model = _customer.GetSingleCustomer(id);
                return BaseReturn.ReturnState<Customer>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<Customer>(0, null, ex.Message);
            }
        }

        [HttpGet]
        [Route("CustomerGetAll")]
        public Response<List<Customer>> CustomerGetAll()
        {
            try
            {
                var model = _customer.GetAllCustomer();
                return BaseReturn.ReturnState<List<Customer>>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<List<Customer>>(0, null, ex.Message);
            }
        }
    }
}