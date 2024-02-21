using Microsoft.AspNetCore.OData.Query;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace eShop.API.Filters
{
    public class SwaggerIgnoreOdataOptionsFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameteresList = context.ApiDescription
                .ParameterDescriptions
                .Where(p => p.Type == typeof(ODataQueryOptions<ItemDto>));

            foreach (var parameter in parameteresList)
            {
                if (parameteresList is not null)
                    operation.Parameters
                        .Remove(operation.Parameters.FirstOrDefault(p => p.Name == parameter.Name));
            }
        }
    }
}
