using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GolAirCrafts.Domain.Entities;
using GolAirCrafts.Domain.Interfaces.Services;
using GolAirCrafts.Service.Validators;

namespace GolAirCrafts.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneService _airplaneService;

        public AirplaneController(IAirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        [HttpGet]
        public IEnumerable<Airplane> GetAll()
        {
            return _airplaneService.GetAll();
        }

        [HttpGet("{id}")]
        public Airplane GetById(int id)
        {
            return _airplaneService.GetById(id);
        }

        [HttpPost]
        public Airplane Insert([FromBody] Airplane obj)
        {
            return _airplaneService.Insert<AirplaneValidator>(obj);
        }

        [HttpPut]
        public Airplane Update([FromBody] Airplane obj)
        {
            return _airplaneService.Update<AirplaneValidator>(obj);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _airplaneService.Delete(id);
        }
    }
}
