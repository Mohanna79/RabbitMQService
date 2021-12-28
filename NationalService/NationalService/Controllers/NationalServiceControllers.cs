using Microsoft.AspNetCore.Mvc;
using NationalCopyService.Services;
using System.Threading.Tasks;
using NationalCopyService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NationalCopyService.Controllers
{
    [Route("api/NationalService")]
    [ApiController]
    public class NationalServiceControllers : ControllerBase
    {

        private readonly NationalService _nationalService;
        private readonly IReceiveNationalService _receiveRepo;

        public NationalServiceControllers(NationalService nationalService, IReceiveNationalService receiveRepo)
        {
            _nationalService = nationalService;
            _receiveRepo = receiveRepo;
        }
        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            var logs = _receiveRepo.Receive();
            var log = logs.Message;
            var createdLogModel = new NationalsService
            {
                Message = log,
            };
            await _nationalService.Create(createdLogModel);
            List<NationalsService> nationalsServices = new List<NationalsService>();
            nationalsServices = await _nationalService.GetAsync();
            return Ok(nationalsServices);
         
        }
    }
}
