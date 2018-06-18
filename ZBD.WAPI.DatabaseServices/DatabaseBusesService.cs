using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBD.WAPI.IServices;
using ZBD.WAPI.Models;
using static MongoDB.Bson.Serialization.BsonSerializationContext;

namespace ZBD.WAPI.DatabaseServices
{
    public class DatabaseBusesService : IBusesService
    {
        private MongoClient mongoClient;
        private IMongoDatabase mongoDatabase;
        public DatabaseBusesService()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
            mongoDatabase = mongoClient.GetDatabase("ZBD");
        }

        public void Add(Bus bus)
        {
            var busesCollection = mongoDatabase.GetCollection<Bus>("buses");

            busesCollection.InsertOne(bus);
        }

        public IList<Bus> Get()
        {
            var busesCollection = mongoDatabase.GetCollection<Bus>("buses").AsQueryable();

            return busesCollection.ToList();
        }

        public Bus Get(Guid id)
        {
            var busesCollection = mongoDatabase.GetCollection<Bus>("buses").AsQueryable();

            return busesCollection.FirstOrDefault(b => b.Id == id);
        }

        public Bus Get(string name)
        {
            var busesCollection = mongoDatabase.GetCollection<Bus>("buses").AsQueryable();

            return busesCollection.FirstOrDefault(b => b.Name == name);
        }

        public void Remove(Guid id)
        {
            var busesCollection = mongoDatabase.GetCollection<Bus>("buses");
            busesCollection.DeleteOne<Bus>(b => b.Id == id);
        }

        public void Update(Bus bus)
        {
            var busesCollection = mongoDatabase.GetCollection<Bus>("buses");

            busesCollection.ReplaceOne(
                Builders<Bus>.Filter.Eq(x => x.Id, bus.Id),
                bus);
        }
    }
}
