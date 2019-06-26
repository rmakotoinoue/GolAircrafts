using GolAirCrafts.Domain.Entities;
using GolAirCrafts.Domain.Interfaces.Repositories;
using GolAirCrafts.Infra.Data.Context;

namespace GolAirCrafts.Infra.Data.Repository
{
    public class AirplaneRepository : BaseRepository<Airplane>, IAirplaneRepository
    {
        public AirplaneRepository(ContextDb _context): base (_context)
        {

        }
    }
}
