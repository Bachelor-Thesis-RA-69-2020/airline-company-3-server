using AirlineCompany3.Model.Domain;
using AirlineCompany3.Repository.DatabaseContext;
using AirlineCompany3.Repository.Interface;

namespace AirlineCompany3.Repository
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        private ServerDatabaseContext _db;

        public FlightRepository(ServerDatabaseContext db) : base(db)
        {
            _db = db;
        }
    }
}
