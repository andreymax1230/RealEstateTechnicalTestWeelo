using Microsoft.AspNetCore.Mvc;
using RealEstateTechnicalTest.Application.Owner.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateTechnicalTest.Api.Controllers
{
    public class OwnerController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<OwnerDto>>> Get()
        {
            var result = await Mediator.Send(new OwnerQuery());
            return Ok(result);
        }
    }
}