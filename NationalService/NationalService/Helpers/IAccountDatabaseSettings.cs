namespace NationalCopyService.Services
{
    public interface IAccountDatabaseSettings
    {
        string NationalServiceCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}