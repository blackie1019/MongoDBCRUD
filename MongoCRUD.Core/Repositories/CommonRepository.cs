using MongoDB.Driver;

namespace MongoCRUD.Core.Repositories
{
    public class CommonRepository
    {   
        protected MongoCredential Credential {get;set;}
        protected MongoClientSettings ClientSettings{get;set;}
        protected MongoClient Client {get;set;}
        protected IMongoDatabase Database {get;set;}

        
        protected CommonRepository()
        {
            this.Credential = MongoCredential.CreateCredential("demo", "dbuser", "pass.123");
            this.ClientSettings  = new MongoClientSettings
            {
                Credentials = new[] { this.Credential },
                Server = new MongoServerAddress("localhost", 32768)
            };
            this.Client = new MongoClient(this.ClientSettings);
            this.Database = this.Client.GetDatabase("demo");
            /* 
            this.Credential = MongoCredential.CreateCredential("poker-band", "dbuser", "pass.123");
            this.ClientSettings  = new MongoClientSettings
            {
                Credentials = new[] { this.Credential },
                Server = new MongoServerAddress("ds147070.mlab.com", 47070)
            };
            this.Client = new MongoClient(this.ClientSettings);
            this.Database = this.Client.GetDatabase("poker-band");
            */
        }
    }
}