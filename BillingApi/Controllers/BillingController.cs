using BillingApi.Infra.Exceptions;
using BillingApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingApi.Controllers
{
    [Route("api/billing")]
    [ApiController]
    public class BillingController : Controller
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService) 
        {
            _billingService = billingService;
        }

        [HttpGet]
        [Route("GetAndProcessFirstData")]
        public async Task<IActionResult> GetAndProcessFirstData()
        {
            try
            {
                await _billingService.GetApiBillingsFirstCustomerFirstProduct();
                return Ok();
            }
            catch (ServiceUnavailableException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "O serviço está indisponível.");
            }
            catch (ApiException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao chamar a API.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao chamar a API. " + e.Message);
            }
        }

        [HttpGet]
        [Route("ProcessBillings")]
        public async Task<IActionResult> ProcessBillings()
        {
            try
            {
                await _billingService.ProcessApiBilling();
                return Ok();
            }
            catch (ServiceUnavailableException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "O serviço está indisponível.");
            }
            catch (ApiException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao chamar a API.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao chamar a API. " + e.Message);
            }
        }
    }
}
