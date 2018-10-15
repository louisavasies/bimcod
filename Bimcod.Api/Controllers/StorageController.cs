using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Bimcod.Api.Utilities;

namespace  Bimcod.Api.Controllers
{
    [Route("api/[controller]")]
    public class StorageController : Controller
    {
        [HttpGet("{containerName}")]
        public IActionResult GetUrlOfContainer(string containerName)
        {
            string containerUrl = new AzureBlobService(containerName).GetFullUrlOfContainer();
            return Ok(containerUrl);
        }


    }
}
