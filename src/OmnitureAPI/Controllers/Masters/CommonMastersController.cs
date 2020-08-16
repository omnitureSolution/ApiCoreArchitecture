using Omniture.Core.Interfaces.Services.Masters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SocietyCareAPI.Controllers.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyCareAPI.Controllers.Masters
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class CommonMastersController : APIBaseController
    {
        private IMasters _masters;
        public CommonMastersController(IMasters masters)
        {
            _masters = masters;
        }

       

        [HttpGet(Name = "countries")]
        [Route("countries")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetCountry()
        {
            var countries = await _masters.GetCountries();
            if (countries == null)
                return NotFound();
            return Ok(countries);
        }

        
         


    }
}
