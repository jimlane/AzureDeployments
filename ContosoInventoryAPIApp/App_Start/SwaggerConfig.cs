using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using ContosoInventoryAPIApp;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ContosoInventoryAPIApp
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c => c.SingleApiVersion("v1", "ContosoInventoryAPIApp"))
                .EnableSwaggerUi(c => { });
        }
    }
}
