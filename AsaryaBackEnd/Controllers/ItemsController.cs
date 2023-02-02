using AsaryaBackEnd.Core.DTOs;
using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsaryaBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : BaseApiController
    {
        public ItemsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
            : base(repository, logger, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var item = await _repository.Item.FindAllAsync(trackChanges: false);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAll)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        // GET api/<ItemsController>/5
        [HttpGet("{id}", Name = "ItemById")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _repository.Item.GetById(id, trackChanges: false);
            if (item is null)
            {
                _logger.LogInfo($"Item with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var itemDto = _mapper.Map<ItemDto>(item);
                return Ok(itemDto);
            }
        }
        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> Update(int id, [FromBody] ItemDto item)
        {
            try
            {
                var itemData = _mapper.Map<Item>(item);

                await _repository.Item.UpdateAsync(itemData);

                await _repository.SaveAsync();
                var itemDto = _mapper.Map<ItemDto>(itemData);
                return Ok(itemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Update)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<ItemsController>
        [HttpPost]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> Post([FromBody] ItemDto item)
        {
            try
            {
                var itemData = _mapper.Map<Item>(item);
                await _repository.Item.CreateAsync(itemData);
                await _repository.SaveAsync();
                var itemDto = _mapper.Map<ItemDto>(itemData);
                return CreatedAtRoute("ItemById",
                    new
                    {
                        Id = itemDto.Id
                    }, itemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Post)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _repository.Item.GetById(id, trackChanges: false);

                if (item is null)
                {
                    _logger.LogInfo($"Item with id: {id} doesn't exist in the database.");
                    return NotFound();
                }

                await _repository.Item.RemoveAsync(item);

                await _repository.SaveAsync();

                var itemDto = _mapper.Map<ItemDto>(item);
                return Ok(itemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Delete)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
