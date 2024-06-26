using AirlineCompany3.Model.Domain;
using AirlineCompany3.Repository.DatabaseContext;
using AirlineCompany3.Repository.Interface;

namespace AirlineCompany3.Repository
{
    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        private ServerDatabaseContext _db;

        public AirportRepository(ServerDatabaseContext db) : base(db)
        {
            _db = db;
        }
    }
}
