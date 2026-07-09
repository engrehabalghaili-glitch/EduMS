using EduMS.Application.Common.CQRS;
using EduMS.Domain.Entities;
using EduMS.Domain.Interfaces;

namespace EduMS.Application.Persons.Commands;

public class CreatePersonCommandHandler(IRepository<Person> personRepository) 
    : ICommandHandler<CreatePersonCommand, long>
{
    public async Task<long> HandleAsync(CreatePersonCommand command, CancellationToken cancellationToken)
    {
        var person = new Person
        {
            FullNameAr = command.FullNameAr,
            FullNameEn = command.FullNameEn,
            NationalId = command.NationalId,
            Gender = command.Gender,
            ContactNumber = command.ContactNumber,
            MedicalInfo = command.MedicalInfo
        };

        await personRepository.AddAsync(person, cancellationToken);
        return person.Id;
    }
}
