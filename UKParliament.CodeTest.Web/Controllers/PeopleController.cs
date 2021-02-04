using UKParliament.CodeTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace UKParliament.CodeTest.Web
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(ModelValidationAttribute))]
    public class PeopleController : BaseController
    {
        private readonly IPersonService _personService;


        public PeopleController(IPersonService personService)
        {
            _personService = personService;
          
        }


        [HttpGet]
        public async Task<ObjectResult> GetAllAsync([FromQuery] string name,
                                                                [FromQuery] string email,
                                                                [FromQuery] DateTime? dateOfBirth)
        {
            var result = await _personService.GetAllAsync(name, email, dateOfBirth);

            return BaseResult(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ObjectResult> GetAsync([FromRoute] int id)
        {
            var result = await _personService.GetAsync(id);
            return BaseResult(result);
        }

        [HttpPost]
        public async Task<ObjectResult> AddAsync([FromBody] PersonModel model)
        {
            var result = await _personService.AddAsync(model);

            return BaseResult(result);
        }

        [HttpPut("{id:int}")]
        public async Task<ObjectResult> UpdateAsync([FromRoute] int id, [FromBody] PersonModel model)
        {
            var result = await _personService.UpdateAsync(id, model);

            return BaseResult(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ObjectResult> RemoveAsync([FromRoute] int id)
        {
            var result = await _personService.RemoveAsync(id);

            return BaseResult(result);
        }
    }
}
