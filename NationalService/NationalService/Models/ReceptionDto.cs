using System;

namespace NationalCopyService.Models
{
    public class ReceptionDto
    {
        public int ReceptionId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ReceptionExaminationId { get; set; }
        public int ExaminationId { get; set; }
        public long Price { get; set; }
        public int ReceptionNumber { get; set; }    
        public DateTime DateTime { get; set; }
    }
}
