using GolAirCrafts.Domain.Entities;
using GolAirCrafts.Domain.Interfaces.Repositories;
using GolAirCrafts.Domain.Interfaces.Services;

namespace GolAirCrafts.Service.Services
{
    public class AirplaneService : BaseService<Airplane>, IAirplaneService
    {
        private readonly IAirplaneRepository _repository;
        public AirplaneService(IAirplaneRepository repository) : base (repository)
        {
            _repository = repository;
        }
    }
}
