using NationalCopyService.Contracts;
using NationalCopyService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalCopyService.Services
{
    public class NumberReceptionRepository : INumberReceptionRepository
    {
        private readonly NationalService _nationalService;
        private readonly IReceiveNationalService _receiveNationalService;

        public NumberReceptionRepository(NationalService nationalService, IReceiveNationalService receiveNationalService)
        {
            _nationalService = nationalService; 
            _receiveNationalService = receiveNationalService;   
        }

        public async Task<int> GetNumber()
        {
            List<NationalsService> Number = new List<NationalsService>();
            Number = await _nationalService.GetAsync();
            int ReceptionNumber = Number.Count();
            return ReceptionNumber;

        }

       
    }
}
