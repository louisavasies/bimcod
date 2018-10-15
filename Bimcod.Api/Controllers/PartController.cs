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
    public class PartController : Controller
    {
        private readonly PartRepository partRepository;
        private readonly IEntityMapper<Part, PartViewModel> entitytoVmMapper;
        private readonly IEntityMapper<PartViewModel, Part> vmToEntityMapper;

        public PartController(PartRepository partRepository, IEntityMapper<Part, PartViewModel> entitytoVmMapper, IEntityMapper<PartViewModel, Part> vmToEntityMapper)
        {
            this.partRepository = partRepository;
            this.entitytoVmMapper = entitytoVmMapper;
            this.vmToEntityMapper = vmToEntityMapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetAllPartsByOptionId(int id)
        {
            var result = partRepository.GetAllPartsByOptionId(id).Select(p => entitytoVmMapper.Map(p)).ToList();
            return Ok(result);
        }
    }
}