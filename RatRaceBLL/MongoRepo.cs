using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Rat_race;

namespace RatRaceBLL
{
    public class MongoRepo : IRepository
    {
        private IMongoDatabase db;
        private IMongoCollection<BsonDocument> _rats;
        private IMongoCollection<BsonDocument> _player;
        private IMongoCollection<BsonDocument> _race;
        private IMongoCollection<BsonDocument> _track;

        public MongoRepo()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://ikhvan95:kagemand69@ratracedb.dkwhaog.mongodb.net/");
            db = dbClient.GetDatabase("RatRaceDB");
            _rats = db.GetCollection<BsonDocument>("Rats");
            _player = db.GetCollection<BsonDocument>("Player");
            _race = db.GetCollection<BsonDocument>("Race");
            _track = db.GetCollection<BsonDocument>("Track");
        }

        public void Save<T>(List<T> save)
        {
            if (typeof(T) == typeof(Rat))
            {
                foreach (T rat in save)
                {
                    var ratDocument = rat.ToBsonDocument(); // Convert Rat object to BsonDocument
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", ratDocument["_id"]); 
                    _rats.ReplaceOne(filter, ratDocument, new ReplaceOptions { IsUpsert = true }); // Upsert the Rat document
                }
            }
        }

        public RaceManager Load(RaceManager raceManager)
        {
            raceManager.Tracks = LoadList<Track>(_track);
            raceManager.PlayerList = LoadList<Player>(_player);
            raceManager.Races = LoadList<Race>(_race);
            raceManager.Rats = LoadList<Rat>(_rats);

            return raceManager;
        }



        private List<T> LoadList<T>(IMongoCollection<BsonDocument> collection)
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var documents = collection.Find(filter).ToList();
            return documents.Select(doc => BsonSerializer.Deserialize<T>(doc)).ToList();
        }
    }
}
