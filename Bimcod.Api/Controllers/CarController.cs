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
    public class CarController : Controller
    {
        private readonly CarRepository carRepository;
        private readonly IEntityMapper<Car, CarViewModel> entitytoVmMapper;
        private readonly IEntityMapper<CarViewModel, Car> vmToEntityMapper;

        public CarController(CarRepository carRepository, IEntityMapper<Car, CarViewModel> entitytoVmMapper, IEntityMapper<CarViewModel, Car> vmToEntityMapper)
        {
            this.carRepository = carRepository;
            this.entitytoVmMapper = entitytoVmMapper;
            this.vmToEntityMapper = vmToEntityMapper;
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody]CarViewModel carVm)
        {
            Car car = new Car
            {
                Model = carVm.Model,
                Type = carVm.Type
            };

            Car newCar = carRepository.AddCar(car);
            if (newCar == null)
            {
                return BadRequest("Car couldn't be added");
            }

            CarViewModel newCarVm = entitytoVmMapper.Map(car);
            return Ok(newCarVm);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            carRepository.DeleteCar(id);
            return Ok();
        }

        [HttpGet]
        [Route("/all/{id}")]
        public IActionResult GetAllCars(int id)
        {
            var result = carRepository.GetAllCars(id).Select(car => entitytoVmMapper.Map(car)).ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            Car car = carRepository.GetCarById(id);
            if(car == null)
            {
                return NotFound("Car doesn't exist");
            }
            CarViewModel carVm = this.entitytoVmMapper.Map(car);
            return Ok(carVm);
        }
    }
}