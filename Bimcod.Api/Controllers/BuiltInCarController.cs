using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bimcod.Api.Models;
using Bimcod.Api.Repositories;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Mappers;

namespace Bimcod.Api.Controllers
{
    [Route("api/[controller]")]
    public class BuiltInCarController : Controller
    {
        private readonly BuiltInCarRepository builtInCarRepository;
        private readonly IEntityMapper<BuiltInCar, BuiltInCarViewModel> entitytoVmMapper;
        private readonly IEntityMapper<BuiltInCarViewModel, BuiltInCar> vmToEntityMapper;

        public BuiltInCarController(BuiltInCarRepository builtInCarRepository, IEntityMapper<BuiltInCar, BuiltInCarViewModel> entitytoVmMapper, IEntityMapper<BuiltInCarViewModel, BuiltInCar> vmToEntityMapper)
        {
            this.builtInCarRepository = builtInCarRepository;
            this.entitytoVmMapper = entitytoVmMapper;
            this.vmToEntityMapper = vmToEntityMapper;
        }

        [HttpGet]
        public IActionResult GetAllCars(int id)
        {
            var result = builtInCarRepository.GetAllBuiltInCars().Select(car => entitytoVmMapper.Map(car)).ToList();
            return Ok(result);
        }
    }
}