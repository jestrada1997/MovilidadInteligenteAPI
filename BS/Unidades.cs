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
    public class Unidades : IRepository<data.Unidad>
    {
        //se implementea el repositorio de mongo a lo interno para que solo la clase lo vea
        internal ApiContext _repository = new ApiContext();

        //agregar la colleccion 
        private IMongoCollection<Unidad> Collection;

        //constructor
        public Unidades()
        {
            //Si la colleccion no existe la crea, de lo contrario la carga
            Collection = _repository.db.GetCollection<Unidad>("Unidades");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Unidad>.Filter.Eq("_id", new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<Unidad> GetAllById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<IEnumerable<Unidad>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(Unidad Unidad)
        {
            await Collection.InsertOneAsync(Unidad);
        }

        public async Task Update(Unidad Unidad)
        {
            var filter = Builders<Unidad>.Filter.Eq(s => s.IdUnidad, Unidad.IdUnidad);
            await Collection.ReplaceOneAsync(filter, Unidad);
        }
    }
}
