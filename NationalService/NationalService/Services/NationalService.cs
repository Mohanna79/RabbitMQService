using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NationalCopyService.Helpers;
using NationalCopyService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace NationalCopyService.Services
{
    public class NationalService 
    {
       
        private readonly IMongoCollection<NationalsService> _nationalcollection;
        public NationalService(IOptions<AccountDatabaseSettings> settings)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("HospitalManagementLog");
            _nationalcollection = database.GetCollection<NationalsService>("NationalService");
        }
        public async Task Create(NationalsService nationalsService)=>
           await _nationalcollection.InsertOneAsync(nationalsService);

        public async Task<List<NationalsService>> GetAsync()=>
            await _nationalcollection.Find(_ => true).ToListAsync();
        public async Task<NationalsService> GetAsync(string Id) =>
           await _nationalcollection.Find(x=>x.Id==Id).FirstOrDefaultAsync();
    }
}
