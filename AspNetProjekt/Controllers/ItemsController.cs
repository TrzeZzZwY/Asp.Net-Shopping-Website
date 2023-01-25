using AspNetProjekt.Models;
using AspNetProjekt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetProjekt.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> Get()
        {
            List<ItemDto> itemsDto = new List<ItemDto>();
            
            var items = _itemService.FindAll().ToList();
            foreach (var item in items)
            {
                ItemDto newItemDto = new ItemDto(item);
                newItemDto.Categories = item.Categories.Select(e => e.CategoryId.ToString()).ToList();
                itemsDto.Add(newItemDto);
            }
            return itemsDto;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> Get(Guid id)
        {
            var item = _itemService.FindBy(id);
            if (item is null)
                return NotFound();
            ItemDto itemDto = new ItemDto(item);
            itemDto.Categories = item.Categories.Select(e => e.CategoryId.ToString()).ToList();
            return itemDto;
        }

        [HttpPost]
        public ActionResult<ItemDto> Add([FromBody] ItemDto itemDto)
        {
            
            if(itemDto is null|| !ModelState.IsValid)
                return BadRequest();
            Item item = itemDto.ConvertTo();
            Guid? guid = _itemService.Save(item);
            if (guid is null)
                return BadRequest();
            return new ItemDto(_itemService.FindBy(guid));
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ItemDto> Delete(Guid id)
        {
            var item = _itemService.FindBy(id);
            if (item is null)
                return NotFound();
            ItemDto itemDto = new ItemDto(item);
            itemDto.Categories = item.Categories.Select(e => e.CategoryId.ToString()).ToList();
            if (!_itemService.Delete(id))
                return BadRequest();

            return itemDto;
        }


        [HttpPut("{id}")]
        public ActionResult<ItemDto> Put(Guid id, [FromBody] ItemDto itemDto)
        {
            if (itemDto is null || id != Guid.Parse(itemDto.ItemId))
                return BadRequest();
            Item item = itemDto.ConvertTo();
            item.ItemId = Guid.Parse(itemDto.ItemId);
            if (_itemService.Update(item))
                return Ok(item);
            return BadRequest();
        }
    }
}
