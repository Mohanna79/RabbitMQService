using System.Threading.Tasks;

namespace NationalCopyService.Contracts
{
    public interface INumberReceptionRepository
    {
        public Task<int> GetNumber();
    }
}
