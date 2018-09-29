using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace TopShelf.IPO.FP.Filter
{
    public class GlobalHttpHeaderFilter : IOperationFilter
    {
        IEnumerable<Parameter> parameters = SwaggerAttachParams.Parameters;
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (parameters.Count() == 0) return;
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();
            Parallel.ForEach(parameters, (parameter) =>
            {
                operation.parameters.Add(parameter);
            });
            operation.parameters.Add(new Parameter { name = "appId", @in = "header", description = "应用ID", required = true, type = "string" });
        }
    }
}
