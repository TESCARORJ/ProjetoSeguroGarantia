using MongoDB.Driver;
using ProjetoSeguroGarantia.Infra.Storage.Collections;
using ProjetoSeguroGarantia.Infra.Storage.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Infra.Storage.Persistence
{
    public class SeguroGarantiaPersistence
    {
        private readonly MongoDBContext _mongoDBContext;

        public SeguroGarantiaPersistence(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public async Task Insert(SeguroGarantiaCollection seguroGarantia)
        {
            await _mongoDBContext.SeguroGarantia.InsertOneAsync(seguroGarantia);
        }

        public async Task Update(SeguroGarantiaCollection seguroGarantia)
        {
            var filter = Builders<SeguroGarantiaCollection>.Filter.Eq(x => x.Guid, seguroGarantia.Guid);
            await _mongoDBContext.SeguroGarantia.ReplaceOneAsync(filter, seguroGarantia);
        }

        public async Task Delete(SeguroGarantiaCollection seguroGarantia)
        {
            var filter = Builders<SeguroGarantiaCollection>.Filter.Eq(x => x.Guid, seguroGarantia.Guid);
            await _mongoDBContext.SeguroGarantia.DeleteOneAsync(filter);
        }

        public async Task<List<SeguroGarantiaCollection>> FindAll()
        {
            var filter = Builders<SeguroGarantiaCollection>.Filter.Where(x => true);
            var result = await _mongoDBContext.SeguroGarantia.FindAsync(filter);
            return result.ToList();
        }

        public async Task<SeguroGarantiaCollection>? Find(Guid guid) 
        {
            var filter = Builders<SeguroGarantiaCollection>.Filter.Eq(x => x.Guid, guid);
            var result = await _mongoDBContext.SeguroGarantia.FindAsync(filter);
            return result.FirstOrDefault();
        }
    }
}
