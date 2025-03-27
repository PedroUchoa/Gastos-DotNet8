using Gastos_DotNet8.Data;
using Gastos_DotNet8.Dtos.Person;
using Gastos_DotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace Gastos_DotNet8.Services.Person
{
    public class PersonService : IPersonInterface
    {
        private readonly AppDbContext _context;

        public PersonService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<PersonModel>> CreatePerson(CreatePersonDto createPersonDto)
        {
            ResponseModel<PersonModel> response = new ResponseModel<PersonModel>();
            try
            {
                PersonModel person = new PersonModel()
                {
                    Name = createPersonDto.Name,
                    Age = createPersonDto.Age
                };
                var newPerson = _context.Add(person);
                await _context.SaveChangesAsync();

                response.Data = await _context.Persons.FirstOrDefaultAsync(personDb => personDb.Id == newPerson.Entity.Id);
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<PersonModel>> GetPersonById(int id)
        {
            ResponseModel<PersonModel> response = new ResponseModel<PersonModel>();
            try
            {

                var person = await _context.Persons.Include(t => t.Transactions).FirstOrDefaultAsync(personDB => personDB.Id == id);

                if (person == null)
                {
                    response.Mensagem = "Person Not Found in the DataBase";
                    return response;
                }

                response.Data = person;
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<PersonModel>>> ListAllPersons()
        {
            ResponseModel<List<PersonModel>> response = new ResponseModel<List<PersonModel>>();
            try
            {
                var persons = await _context.Persons.Include(t=>t.Transactions).ToListAsync();

                response.Data = persons;

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<PersonModel>>> UpdatePerson(UpdatePersonDto updatePersonDto)
        {
            ResponseModel<List<PersonModel>> response = new ResponseModel<List<PersonModel>>();
            try
            {
                var person = await _context.Persons.FirstOrDefaultAsync(personDb => personDb.Id == updatePersonDto.Id); 
                if(person == null)
                {
                    response.Mensagem = "Person Not Found";
                    return response;
                }
                person.Name = updatePersonDto.Name;
                person.Age = updatePersonDto.Age;

                _context.Update(person);
                await _context.SaveChangesAsync();
                response.Data = await _context.Persons.Include(t => t.Transactions).ToListAsync();
                response.Mensagem = "Person Updated";
                return response;

            }
            catch (Exception ex) 
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<PersonModel>>> DeletePerson(int idPerson)
        {
            ResponseModel<List<PersonModel>> response = new ResponseModel<List<PersonModel>>();
            try
            {
                var person = await _context.Persons.FirstOrDefaultAsync(personDb => personDb.Id == idPerson);
                if(person == null)
                {
                    response.Mensagem = "No Person Found";
                    return response;
                }

                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
                response.Data = await _context.Persons.Include(t => t.Transactions).ToListAsync();
                response.Mensagem = "Person Removed";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

    }
}