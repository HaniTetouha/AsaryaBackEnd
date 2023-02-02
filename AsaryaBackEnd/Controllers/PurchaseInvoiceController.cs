using AsaryaBackEnd.Core.DTOs;
using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsaryaBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseInvoicesController : BaseApiController
    {
        public PurchaseInvoicesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
            : base(repository, logger, mapper)
        {
        }

        // GET: api/<PurchaseInvoiceController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var item = await _repository.PurchaseInvoice.FindAllAsync(trackChanges: false);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAll)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<PurchaseInvoiceController>/5
        [HttpGet("{id}", Name = "PurchaseInvoiceById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var salesInvoice = await _repository.PurchaseInvoice.GetById(id, trackChanges: false);
                if (salesInvoice is null)
                {
                    _logger.LogInfo($"Purchase Invoice with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var salesInvoiceDto = _mapper.Map<PurchaseInvoiceDto>(salesInvoice);
                    return Ok(salesInvoiceDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Get)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<PurchaseInvoiceController>
        [HttpPost]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> Post([FromBody] PurchaseInvoiceDto salesInvoice)
        {
            try
            {
                var invoiceData = _mapper.Map<PurchaseInvoice>(salesInvoice);
                await _repository.PurchaseInvoice.CreateAsync(invoiceData);
                await _repository.SaveAsync();
                var invoiceReturn = _mapper.Map<PurchaseInvoiceDto>(invoiceData);
                return CreatedAtRoute("PurchaseInvoiceById",
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

        // PUT api/<PurchaseInvoiceController>/5
        [HttpPut("{id}")]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> Update(int id, [FromBody] PurchaseInvoiceDto salesInvoice)
        {
            try
            {
                var invoiceData = _mapper.Map<PurchaseInvoice>(salesInvoice);

                await _repository.PurchaseInvoice.UpdateAsync(invoiceData);

                if (invoiceData.Status == InvoiceStatus.Saved)
                    CommitInvoiceEntry(invoiceData);

                await _repository.SaveAsync();
                var salesInvoiceDto = _mapper.Map<PurchaseInvoiceDto>(invoiceData);
                return Ok(salesInvoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Update)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<PurchaseInvoiceController>/5
        [HttpDelete("{id}")]
        [Authorize]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var salesInvoice = await _repository.PurchaseInvoice.GetById(id, trackChanges: false);

                if (salesInvoice is null)
                {
                    _logger.LogInfo($"Purchase Invoice with id: {id} doesn't exist in the database.");
                    return NotFound();
                }

                if (salesInvoice.Status == InvoiceStatus.Saved)
                    CommitInvoiceEntry(salesInvoice, false);

                salesInvoice.Status = InvoiceStatus.Canceled;

                await _repository.PurchaseInvoice.UpdateAsync(salesInvoice);

                await _repository.SaveAsync();

                var salesInvoiceDto = _mapper.Map<PurchaseInvoiceDto>(salesInvoice);
                return Ok(salesInvoiceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Delete)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        protected void CommitInvoiceEntry(PurchaseInvoice entity, bool add = true)
        {
            foreach (var entry in entity.PurchaseInvoiceEntry)
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
