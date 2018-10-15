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
    public class ModuleController : Controller
    {
        private readonly ModuleRepository moduleRepository;
        private readonly IEntityMapper<Module, ModuleViewModel> entitytoVmMapper;
        private readonly IEntityMapper<ModuleViewModel, Module> vmToEntityMapper;

        public ModuleController(ModuleRepository moduleRepository, IEntityMapper<Module, ModuleViewModel> entitytoVmMapper, IEntityMapper<ModuleViewModel, Module> vmToEntityMapper)
        {
            this.moduleRepository = moduleRepository;
            this.entitytoVmMapper = entitytoVmMapper;
            this.vmToEntityMapper = vmToEntityMapper;
        }

        [HttpGet("{version}")]
        public IActionResult GetAllModulesFor(string version)
        {
            var result = moduleRepository.GetAllModulesFor(version).Select(m => entitytoVmMapper.Map(m));
            return Ok(result);
        }

    }
}