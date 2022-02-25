using Models.Products;
using Ronvell.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace Ronvell.Controllers
{
    public class ProductController : ApiController
    {

        Business.Services.ProductService _product;

        public ProductController()
        {
            if (_product == null)
                _product = new Business.Services.ProductService();
        }


        [HttpPost]
        [Route("ProductAdd")]
        public Response<int> ProductAdd([FromBody] Product model)
        {
            try
            {
                int state = _product.ProductAdd(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0,ex.Message);
            }
        }

        [HttpPut]
        [Route("ProductUpdate")]
        public Response<int> ProductUpdate([FromBody] Product model)
        {
            try
            {
                int state = _product.ProductUpdate(model);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpPut]
        [Route("ProductDelete")]
        public Response<int> ProductDelete([FromUri]int id)
        {
            try
            {
                int state = _product.ProductDelete(id);
                return BaseReturn.ReturnState<int>(state, 1);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<int>(0, 0, ex.Message);
            }
        }

        [HttpGet]
        [Route("ProductGetAll")]
        public Response<List<Product>> ProductGetAll()
        {
            try
            {
                var model = _product.GetAllProduct();
                return BaseReturn.ReturnState<List<Product>>(1,model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<List<Product>>(0, null, ex.Message);
            }
        }

        [HttpGet]
        [Route("ProductByIds")]
        public Response<Product> ProductByIds([FromUri] int id)
        {
            try
            {
                var model= _product.GetSingleProduct(id);
                return BaseReturn.ReturnState<Product>(1, model);
            }
            catch (Exception ex)
            {
                return BaseReturn.ReturnState<Product>(0, null,ex.Message);
            }
        }


    }
}