using EduMS.Application.Common.CQRS;

namespace EduMS.Application.Persons.Commands;

public record CreatePersonCommand(
    string FullNameAr,
    string FullNameEn,
    string NationalId,
    EduMS.Domain.Enums.Gender Gender,
    string? ContactNumber,
    string? MedicalInfo
) : ICommand<long>;
