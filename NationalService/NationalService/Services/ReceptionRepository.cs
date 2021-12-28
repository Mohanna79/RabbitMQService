using NationalCopyService.Contracts;
using NationalCopyService.Models;
using System;

namespace NationalCopyService.Services
{
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly IReceiveNationalService _receiveNationalService;

        public ReceptionRepository(IReceiveNationalService receiveNationalService)
        {
            _receiveNationalService = receiveNationalService;

        }

        public int GetInformation()
        {
            var mw = _receiveNationalService.Receive();
            var reception = mw.Reception;
            ReceptionDto res = new ReceptionDto
            {
                ReceptionId = int.Parse(reception),
                PatientId = int.Parse(reception),
                DoctorId = int.Parse(reception),
                ReceptionExaminationId = int.Parse(reception),
                ExaminationId =int.Parse(reception),
                Price =long.Parse(reception),
                DateTime = DateTime.Now,
            };
            return res.DoctorId;

        }
    }
}
