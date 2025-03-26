using Gastos_DotNet8.Dtos.Person;
using Gastos_DotNet8.Models;
using Gastos_DotNet8.Services.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Gastos_DotNet8.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonInterface _personInterface;

        public PersonController(IPersonInterface personInterface) 
        {  
            _personInterface = personInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<PersonModel>>> CreatePerson(CreatePersonDto person)
        {
            var returnedPerson = await _personInterface.CreatePerson(person);
            return Created(new Uri(Request.GetEncodedUrl()+"/"+ returnedPerson.Data.Id), returnedPerson);
        }


        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<PersonModel>>>> ListAllPersons()
        {
            var persons = await _personInterface.ListAllPersons();
            return Ok(persons);
        }

        [HttpGet("{idPerson}")]
        public async Task<ActionResult<ResponseModel<PersonModel>>> GetById(int idPerson)
        {
            var person = await _personInterface.GetPersonById(idPerson);
            return Ok(person);
        }

        [HttpPut]
        public async Task<ActionResult<List<ResponseModel<PersonModel>>>> UpdatePerson(UpdatePersonDto updatePersonDto)
        {
            var persons = await _personInterface.UpdatePerson(updatePersonDto);
            return Ok(persons);

        }

        [HttpDelete("{idPerson}")]
        public async Task<ActionResult<List<ResponseModel<PersonModel>>>> DeletePerson(int idPerson)
        {
            var person = await _personInterface.DeletePerson(idPerson);
            return Ok(person);
        }


    }
}
