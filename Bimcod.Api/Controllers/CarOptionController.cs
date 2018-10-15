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
    public class CarOptionController : Controller
    {
        private readonly CarOptionRepository carOptionRepository;
        private readonly IEntityMapper<CarOption, CarOptionViewModel> entitytoVmMapper;
        private readonly IEntityMapper<CarOptionViewModel, CarOption> vmToEntityMapper;

        public CarOptionController(CarOptionRepository carOptionRepository, IEntityMapper<CarOption, CarOptionViewModel> entitytoVmMapper, IEntityMapper<CarOptionViewModel, CarOption> vmToEntityMapper)
        {
            this.carOptionRepository = carOptionRepository;
            this.entitytoVmMapper = entitytoVmMapper;
            this.vmToEntityMapper = vmToEntityMapper;
        }

        [HttpPost]
        public IActionResult CreateCarOption([FromBody]CarOptionViewModel carOptionVm)
        {
            CarOption carOption = new CarOption()
            {
                CarId = carOptionVm.CarId,
                OptionId = carOptionVm.OptionId
            };

            CarOption newCarOption = carOptionRepository.AddCarOption(carOption);
            if(newCarOption == null)
            {
                return BadRequest("CarOption couldn't be created");
            }
            CarOptionViewModel carOptionViewModel = entitytoVmMapper.Map(carOption);
            return Ok(carOptionViewModel);
        }

        [HttpDelete("{carId}/{optionId}")]
        public IActionResult RemoveCarOption(int carId, int optionId)
        {
            carOptionRepository.RemoveCarOption(carId, optionId);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = carOptionRepository.GetAll().Select(co => entitytoVmMapper.Map(co)).ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAllByCarId(int id)
        {
            var result = carOptionRepository.GetAllByCarId(id).Select(co => entitytoVmMapper.Map(co)).ToList();
            return Ok(result);
        }
    }
}