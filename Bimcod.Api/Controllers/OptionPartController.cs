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
    public class OptionPartController : ControllerBase
    {
        private readonly OptionPartRepository optionPartRepository;
        private readonly IEntityMapper<OptionPart, OptionPartViewModel> entitytoVmMapper;
        private readonly IEntityMapper<OptionPartViewModel, OptionPart> vmToEntityMapper;
        private readonly PartRepository partRepository;
        private readonly IEntityMapper<Part, PartViewModel> parttoVmMapper;
        private readonly IEntityMapper<PartViewModel, Part> vmToPartMapper;

        public OptionPartController(OptionPartRepository optionPartRepository, IEntityMapper<OptionPart, OptionPartViewModel> entitytoVmMapper, IEntityMapper<OptionPartViewModel, OptionPart> vmToEntityMapper, PartRepository partRepository, IEntityMapper<Part, PartViewModel> parttoVmMapper, IEntityMapper<PartViewModel, Part> vmToPartMapper)
        {
            this.optionPartRepository = optionPartRepository;
            this.entitytoVmMapper = entitytoVmMapper;
            this.vmToEntityMapper = vmToEntityMapper;
            this.partRepository = partRepository;
            this.parttoVmMapper = parttoVmMapper;
            this.vmToPartMapper = vmToPartMapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetPartsByOptionId(int id)
        {
            var parts = partRepository.GetAllPartsByOptionId(id);
            var result = parts.Select(part => this.parttoVmMapper.Map(part)).ToList();
            return Ok(result);
        }
    }
}