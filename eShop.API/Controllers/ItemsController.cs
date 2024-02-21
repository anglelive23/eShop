using eShop.Application.Features.Items.Commands.CreateItem;
using eShop.Application.Features.Items.Commands.DeleteItem;
using eShop.Application.Features.Items.Commands.UpdateItem;
using eShop.Application.Features.Items.Queries.GetItemDetails;
using eShop.Application.Features.Items.Queries.GetItemsList;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eShop.API.Controllers
{
    [Route("api/odata")]
    public class ItemsController(IMediator mediator) : ODataController
    {
        #region GET
        [HttpGet("items")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Customer, Admin")]
        public async Task<IActionResult> GetAllItems(ODataQueryOptions<ItemDto> options)
        {
            var items = await mediator
                    .Send(new GetItemsListQuery() { QueryOptions = options });
            return Ok(items);
        }

        [HttpGet("items({key})")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Customer, Admin")]
        public async Task<IActionResult> GetItemById(int key, ODataQueryOptions<ItemDto> options)
        {
            var item = await mediator
                .Send(new GetItemDetailsQuery
                {
                    Id = key,
                    QueryOptions = options
                });

            if (item is null)
                return NotFound($"Item with Id: {key} was not found!");

            return Ok(item);
        }
        #endregion

        #region Post
        [HttpPost("items")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddItem([FromBody] CreateItemDto itemDto)
        {
            var item = await mediator
                .Send(new CreateItemCommand
                {
                    ItemDto = itemDto
                });

            if (item is null)
                return BadRequest("Item not created!");

            return Created(item);
        }
        #endregion

        #region PUT
        [HttpPut("items({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateItem(int key, [FromBody] UpdateItemDto updateItemDto)
        {
            var currentItem = await mediator
                .Send(new UpdateItemCommand
                {
                    Key = key,
                    ItemDto = updateItemDto
                });

            if (currentItem == null)
                return NotFound("Item not found!");

            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("items({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveItem(int key)
        {
            var currentItem = await mediator
                .Send(new DeleteItemCommand
                {
                    Key = key
                });

            if (currentItem is false)
                return NotFound("Item not found!");

            return NoContent();
        }
        #endregion
    }
}
