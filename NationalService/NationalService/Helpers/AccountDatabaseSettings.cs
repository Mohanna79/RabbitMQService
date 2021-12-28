using NationalCopyService.Services;

namespace NationalCopyService.Helpers
{
    public class AccountDatabaseSettings : IAccountDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string NationalServiceCollectionName { get ; set ; }
    }
}
