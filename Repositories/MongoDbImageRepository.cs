using System;
using Api.Entities;
using Api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Api.Repositories
{
    public class MongoDbImageRepository : IImageRepository
    {
        private const string databaseName = "crossNotes";
        private const string collectionName = "notes";
        private const string notesCollection = "crossNotescollection";
        private readonly IMongoCollection<ImageData> imagesCollection;
        private readonly FilterDefinitionBuilder<ImageData> filterBuilder = Builders<ImageData>.Filter;
        public MongoDbImageRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            imagesCollection = database.GetCollection<ImageData>(notesCollection);
        }
        public async Task CreteImageAsync(ImageData image)
        {
            await imagesCollection.InsertOneAsync(image);
        }

        public async Task DeleteImageAsync(string id)
        {
            var filter = filterBuilder.Eq(imagedata => imagedata.id, id);
            await imagesCollection.DeleteOneAsync(filter);
        }

        public async Task<ImageData> GetImageAsyc(string id)
        {
            var filter = filterBuilder.Eq(imagedata => imagedata.id, id);
            return await imagesCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ImageData>> GetImagesAsync()
        {
            return await imagesCollection.Find(f => true).ToListAsync();
        }

        public async Task UpdateImageAsync(ImageData item)
        {
            var filter = filterBuilder.Eq(existingImage => existingImage.id, item.id);
            await imagesCollection.ReplaceOneAsync(filter, item);
        }
    }
}