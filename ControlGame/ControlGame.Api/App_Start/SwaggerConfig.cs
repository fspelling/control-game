using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ControlGame.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            config.EnableSwagger(c =>
            {
                c.BasicAuth("Basic").Description("Bearer Token Authentication");
                c.OperationFilter<AddRequiredHeaderParameter>();

                c.SingleApiVersion("v1", "ControlGame");
            });
        }
    }

    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            operation.parameters.Add(new Parameter()
            {
                name = "Authorization",
                @in = "header",
                type = "string"
            });
        }
    }
}
