using AsaryaBackEnd.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsaryaBackEnd.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : BaseApiController
    {
        public ItemsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) 
            : base(repository, logger, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var item = await _repository.Item.FindAllAsync(trackChanges: false);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetItems)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
