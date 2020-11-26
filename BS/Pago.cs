using API.DO.Objects;
using DAL.EF;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = API.DO.Objects;

namespace BS
{
    public class Pagos : IRepository<data.Pago>
    {
        //se implementea el repositorio de mongo a lo interno para que solo la clase lo vea
        internal ApiContext _repository = new ApiContext();

        //agregar la colleccion
        private IMongoCollection<Pago> Collection;

        //constructor
        public Pagos()
        {
            //Si la colleccion no existe la crea, de lo contrario la carga
            Collection = _repository.db.GetCollection<Pago>("pagos");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Pago>.Filter.Eq("_id", new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<Pago> GetAllById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<IEnumerable<Pago>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(Pago Pago)
        {
            await Collection.InsertOneAsync(Pago);
        }

        public async Task Update(Pago Pago)
        {
            var filter = Builders<Pago>.Filter.Eq(s => s.IdPago, Pago.IdPago);
            await Collection.ReplaceOneAsync(filter, Pago);
        }
    }
}
