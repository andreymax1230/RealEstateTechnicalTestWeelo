using Microsoft.AspNetCore.Mvc;
using RealEstateTechnicalTest.Application.Property.Commands;
using RealEstateTechnicalTest.Application.Property.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateTechnicalTest.Api.Controllers
{
    public class PropertyController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<PropertyDto>>> Get([FromQuery] QueryPropertyFilter model)
        {
            var result = await Mediator.Send(model);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(CreatePropertyCommand model)
        {
            var result = await Mediator.Send(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put(UpdatePropertyCommand model)
        {
            var result = await Mediator.Send(model);
            return Ok(result);
        }

        [HttpPut("price")]
        public async Task<ActionResult<bool>> UpdatePrice(UpdatePricePropertyCommand model)
        {
            var result = await Mediator.Send(model);
            return Ok(result);
        }

    }
}