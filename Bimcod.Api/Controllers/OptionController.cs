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
    public class OptionController : Controller
    {
        private readonly OptionRepository optionRepository;
        private readonly IEntityMapper<Option, OptionViewModel> entitytoVmMapper;
        private readonly IEntityMapper<OptionViewModel, Option> vmToEntityMapper;

        public OptionController(OptionRepository optionRepository, IEntityMapper<Option, OptionViewModel> entitytoVmMapper, IEntityMapper<OptionViewModel, Option> vmToEntityMapper)
        {
            this.optionRepository = optionRepository;
            this.entitytoVmMapper = entitytoVmMapper;
            this.vmToEntityMapper = vmToEntityMapper;
        }

        [HttpGet]
        public IActionResult GetAllOptionsFor(string version)
        {
            var result = optionRepository.GetAllOptionsFor(version).Select(o => entitytoVmMapper.Map(o)).ToList();
            return Ok(result);
        }
    }
}