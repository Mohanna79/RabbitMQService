using NationalCopyService.Models;
using RestEase;
using System.Threading.Tasks;

namespace NationalCopyService.Contracts
{
    public interface ILogService
    {
        [AllowAnyStatusCode]
        [Post("api/Reception/CreateReception")]
        Task<Response<ReceptionDto>> Create([Body] ReceptionDto model);
    }
}
