using AsaryaBackEnd.Core.DTOs;
using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsaryaBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesInvoicesController : BaseApiController
    {
        public SalesInvoicesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
            : base(repository, logger, mapper)
        {
        }

        // GET: api/<SalesInvoiceController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var item = await _repository.SalesInvoice.FindAllAsync(trackChanges: false);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAll)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<SalesInvoiceController>/5
        [HttpGet("{id}", Name = "SalesInvoiceById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var salesInvoice = await _repository.SalesInvoice.GetById(id, trackChanges: false);
                if (salesInvoice is null)
                {
                    _logger.LogInfo($"Sales Invoice with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var salesInvoiceDto = _mapper.Map<SalesInvoiceDto>(salesInvoice);
                    return Ok(salesInvoiceDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Get)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<SalesInvoiceController>
        [HttpPost]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> Post([FromBody] SalesInvoiceDto salesInvoice)
        {
            try
            {
                var invoiceData = _mapper.Map<SalesInvoice>(salesInvoice);
                await _repository.SalesInvoice.CreateAsync(invoiceData);
                await _repository.SaveAsync();
                var invoiceReturn = _mapper.Map<SalesInvoiceDto>(invoiceData);
                return CreatedAtRoute("SalesInvoiceById",
                    new
                    {
                        Id = invoiceReturn.Id
                    }, invoiceReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Post)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<SalesInvoiceController>/5
        [HttpPut("{id}")]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> Update(int id, [FromBody] SalesInvoiceDto salesInvoice)
        {
            try
            {
                var invoiceData = _mapper.Map<SalesInvoice>(salesInvoice);

                await _repository.SalesInvoice.UpdateAsync(invoiceData);

                if (invoiceData.Status == InvoiceStatus.Saved)
                    CommitInvoiceEntry(invoiceData, false);

                await _repository.SaveAsync();
                var salesInvoiceDto = _mapper.Map<SalesInvoiceDto>(invoiceData);
                return Ok(salesInvoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Update)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<SalesInvoiceController>/5
        [HttpDelete("{id}")]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var salesInvoice = await _repository.SalesInvoice.GetById(id, trackChanges: false);

                if (salesInvoice is null)
                {
                    _logger.LogInfo($"Sales Invoice with id: {id} doesn't exist in the database.");
                    return NotFound();
                }

                if (salesInvoice.Status == InvoiceStatus.Saved)
                    CommitInvoiceEntry(salesInvoice);

                salesInvoice.Status = InvoiceStatus.Canceled;

                await _repository.SalesInvoice.UpdateAsync(salesInvoice);

                await _repository.SaveAsync();

                var salesInvoiceDto = _mapper.Map<SalesInvoiceDto>(salesInvoice);
                return Ok(salesInvoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Delete)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        protected void CommitInvoiceEntry(SalesInvoice entity, bool add = true)
        {
            foreach (var entry in entity.SalesInvoiceEntry)
            {
                var item = _repository.Item.GetById(entry.Id, trackChanges: true).Result;
                if (add)
                {

                    if (item != null)
                        item.Quantity += entry.Quantity;
                }
                else
                {
                    if (item != null)
                        item.Quantity -= entry.Quantity;
                }
            };
        }
    }
}
