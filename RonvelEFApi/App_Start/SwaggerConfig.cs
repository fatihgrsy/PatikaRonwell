using System.Web.Http;
using WebActivatorEx;
using RonvelEFApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace RonvelEFApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        
                        c.SingleApiVersion("v1", "RonvelEFApi");
                    })
                .EnableSwaggerUi(c =>
                    {
                        
                    });
        }
    }
}
