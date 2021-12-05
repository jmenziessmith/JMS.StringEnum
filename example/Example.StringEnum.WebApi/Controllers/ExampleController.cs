using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace Example.StringEnum.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ExampleResponse))]
        public IActionResult Get()
        {
            var randomValue = MyEnum.AllValues.OrderBy(x => Guid.NewGuid()).First();

            var response = new ExampleResponse
            {
                EnumValue = randomValue,
                StringValue = Guid.NewGuid().ToString()
            };

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ExampleResponse))]
        public IActionResult Post([FromBody] ExampleRequest request)
        { 
            var response = new ExampleResponse
            {
                EnumValue = request.EnumValue,
                StringValue = request.StringValue,
                IsEnumValueKnown = request.EnumValue.IsKnownValue()
            };

            return Ok(response);
        }
    }
}
