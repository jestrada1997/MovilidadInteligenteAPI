using Repository;
using DAL.EF;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = API.DO.Objects;
using API.DO.Objects;

namespace BS
{
    public class Bitacoras : IRepository<data.Bitacora>
    {
        //se implementea el repositorio de mongo a lo interno para que solo la clase lo vea
        internal ApiContext _repository = new ApiContext();

        //agregar la colleccion 
        private IMongoCollection<Bitacora> Collection;

        //constructor
        public Bitacoras()
        {
            //Si la colleccion no existe la crea, de lo contrario la carga
            Collection = _repository.db.GetCollection<Bitacora>("Bitacoras");
        }
        public async Task Delete(string id)
        {
            //se debe buscar primero, se filtra y se compara con builder 
            var filter = Builders<Bitacora>.Filter.Eq("_id", new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<Bitacora> GetAllById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }
        public async Task<IEnumerable<Bitacora>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(Bitacora Bitacora)
        {
            await Collection.InsertOneAsync(Bitacora);
        }

        public async Task Update(Bitacora Bitacora)
        {
            var filter = Builders<Bitacora>.Filter.Eq(s => s.IdBitacora, Bitacora.IdBitacora);
            await Collection.ReplaceOneAsync(filter, Bitacora);
        }
    }
}
