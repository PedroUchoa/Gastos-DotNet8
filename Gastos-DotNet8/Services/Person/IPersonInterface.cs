using Gastos_DotNet8.Dtos.Person;
using Gastos_DotNet8.Models;

namespace Gastos_DotNet8.Services.Person
{
    public interface IPersonInterface
    {
        Task<ResponseModel<List<PersonModel>>> ListAllPersons();
        Task<ResponseModel<PersonModel>> GetPersonById(int id);
        Task<ResponseModel<PersonModel>> CreatePerson(CreatePersonDto createPersonDto);
        Task<ResponseModel<List<PersonModel>>> UpdatePerson(UpdatePersonDto updatePersonDto);
        Task<ResponseModel<List<PersonModel>>> DeletePerson(int idPerson);


    }
}
