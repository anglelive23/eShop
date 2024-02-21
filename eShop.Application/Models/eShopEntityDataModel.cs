using eShop.Application.Models.Dtos;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace eShop.Application.Models
{
    public class eShopEntityDataModel
    {
        public IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<ItemDto>("Items");

            builder.EnableLowerCamelCase();
            return builder.GetEdmModel();
        }
    }
}
