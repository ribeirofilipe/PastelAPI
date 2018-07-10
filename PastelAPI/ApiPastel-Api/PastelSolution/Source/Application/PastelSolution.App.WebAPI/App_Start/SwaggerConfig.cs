using System.Web.Http;
using WebActivatorEx;
using PastelSolution.App.WebAPI;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace PastelSolution.App.WebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                 .EnableSwagger(c =>
                 {
                     c.SingleApiVersion("v1", "PastelSolution.WebAPI.Api");
                     c.IncludeXmlComments(GetXmlCommentsPath());
                 })
                 .EnableSwaggerUi(c =>
                 {

                 });
        }

        protected static string GetXmlCommentsPath()
        {
            return String.Format(@"{0}\bin\Swagger.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}

