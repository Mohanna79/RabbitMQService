using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationalCopyService.Contracts;
using NationalCopyService.Models;
using System;
using System.Threading.Tasks;

namespace NationalCopyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionController : ControllerBase
    {
        private readonly INumberReceptionRepository _numberReceptionRepository;
        private readonly ILogService _logService;
        private readonly IReceptionRepository _receptionRepository;

        public ReceptionController(IReceptionRepository receptionRepository, ILogService logService, INumberReceptionRepository numberReceptionRepository)
        {
            _logService = logService;
            _receptionRepository = receptionRepository;
            _numberReceptionRepository = numberReceptionRepository;
          
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                int receptionsNumber = await _numberReceptionRepository.GetNumber();
                await _logService.Create(new ReceptionDto()
                {
                   ReceptionNumber = receptionsNumber
                   
                });
                return Ok(receptionsNumber);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }
    }
}
